using Lab_3.Domain;
using Lab_3.Domain.Utils;
using Lab_3.Repositories;
using Lab_3.Services;
using Moq;
using Semaphore = Lab_3.Services.Semaphore;

namespace Lab_3.Tests;

public class SemaphoreTests
{
    private CarStation _robotElectricStation;
    private CarStation _robotGasStation;
    private CarStation _peopleElectricStation;
    private CarStation _peopleGasStation;

    private LinkedListQueue<Car> _robotElectricQueue;
    private ArrayQueue<Car> _robotGasQueue;
    private LinkedListQueue<Car> _peopleElectricQueue;
    private ArrayQueue<Car> _peopleGasQueue;

    private Mock<IRefuelable> _mockElectricRefuelingService;
    private Mock<IRefuelable> _mockGasRefuelingService;
    private Mock<IDineable> _mockDiningService;

    private Semaphore _semaphore;

    [SetUp]
    public void Setup()
    {
        _mockDiningService = new Mock<IDineable>();
        _mockElectricRefuelingService = new Mock<IRefuelable>();
        _mockGasRefuelingService = new Mock<IRefuelable>();

        _robotElectricQueue = new LinkedListQueue<Car>();
        _robotGasQueue = new ArrayQueue<Car>();
        _peopleElectricQueue = new LinkedListQueue<Car>();
        _peopleGasQueue = new ArrayQueue<Car>();

        _robotElectricStation = new CarStation(
            _mockDiningService.Object,
            _mockElectricRefuelingService.Object,
            _robotElectricQueue
        );

        _robotGasStation = new CarStation(
            _mockDiningService.Object,
            _mockGasRefuelingService.Object,
            _robotGasQueue
        );

        _peopleElectricStation = new CarStation(
            _mockDiningService.Object,
            _mockElectricRefuelingService.Object,
            _peopleElectricQueue
        );

        _peopleGasStation = new CarStation(
            _mockDiningService.Object,
            _mockGasRefuelingService.Object,
            _peopleGasQueue
        );

        _semaphore = new Semaphore(
            _robotElectricStation,
            _robotGasStation,
            _peopleElectricStation,
            _peopleGasStation
        );
    }

    [Test]
    public void DispatchCar_ElectricCarForRobots_AddedToRobotElectricStation()
    {
        var json =
            "{\"id\": 5, \"type\": \"ELECTRIC\", \"passengers\": \"ROBOTS\", \"isDining\": false, \"consumption\": 49}";
        var car = CarParser.ParseFromJson(json);

        _semaphore.DispatchCar(car);

        Assert.That(_robotElectricQueue.Count, Is.EqualTo(1));
        Assert.That(_robotGasQueue.Count, Is.EqualTo(0));
        Assert.That(_peopleElectricQueue.Count, Is.EqualTo(0));
        Assert.That(_peopleGasQueue.Count, Is.EqualTo(0));
    }

    [Test]
    public void DispatchCar_GasCarForPeople_AddedToPeopleGasStation()
    {
        var json =
            "{\"id\": 2, \"type\": \"GAS\", \"passengers\": \"PEOPLE\", \"isDining\": true, \"consumption\": 42}";
        var car = CarParser.ParseFromJson(json);

        _semaphore.DispatchCar(car);

        Assert.That(_robotElectricQueue.Count, Is.EqualTo(0));
        Assert.That(_robotGasQueue.Count, Is.EqualTo(0));
        Assert.That(_peopleElectricQueue.Count, Is.EqualTo(0));
        Assert.That(_peopleGasQueue.Count, Is.EqualTo(1));
    }

    [Test]
    public void ServeAllCars_MultipleCars_AllServedCorrectly()
    {
        var carJsons = new[]
        {
            "{\"id\": 5, \"type\": \"ELECTRIC\", \"passengers\": \"ROBOTS\", \"isDining\": false, \"consumption\": 49}",
            "{\"id\": 2, \"type\": \"GAS\", \"passengers\": \"PEOPLE\", \"isDining\": true, \"consumption\": 42}",
            "{\"id\": 6, \"type\": \"ELECTRIC\", \"passengers\": \"PEOPLE\", \"isDining\": false, \"consumption\": 46}",
            "{\"id\": 8, \"type\": \"GAS\", \"passengers\": \"ROBOTS\", \"isDining\": true, \"consumption\": 25}"
        };

        foreach (var json in carJsons)
        {
            var car = CarParser.ParseFromJson(json);
            _semaphore.DispatchCar(car);
        }

        Assert.That(_robotElectricQueue.Count, Is.EqualTo(1));
        Assert.That(_robotGasQueue.Count, Is.EqualTo(1));
        Assert.That(_peopleElectricQueue.Count, Is.EqualTo(1));
        Assert.That(_peopleGasQueue.Count, Is.EqualTo(1));

        _semaphore.ServeAllCars();

        Assert.That(_robotElectricQueue.Count, Is.EqualTo(0));
        Assert.That(_robotGasQueue.Count, Is.EqualTo(0));
        Assert.That(_peopleElectricQueue.Count, Is.EqualTo(0));
        Assert.That(_peopleGasQueue.Count, Is.EqualTo(0));
    }

    [Test]
    public void ServeAllCars_Statistics_CorrectServicesCalled()
    {
        var carJsons = new[]
        {
            "{\"id\": 1, \"type\": \"GAS\", \"passengers\": \"PEOPLE\", \"isDining\": true, \"consumption\": 20}",
            "{\"id\": 5, \"type\": \"ELECTRIC\", \"passengers\": \"PEOPLE\", \"isDining\": false, \"consumption\": 49}",
            "{\"id\": 6, \"type\": \"ELECTRIC\", \"passengers\": \"ROBOTS\", \"isDining\": false, \"consumption\": 46}",
            "{\"id\": 9, \"type\": \"GAS\", \"passengers\": \"ROBOTS\", \"isDining\": false, \"consumption\": 25}"
        };

        foreach (var json in carJsons)
        {
            var car = CarParser.ParseFromJson(json);
            _semaphore.DispatchCar(car);
        }

        _semaphore.ServeAllCars();

        _mockElectricRefuelingService.Verify(r => r.Refuel(It.IsAny<string>()), Times.Exactly(2));
        _mockGasRefuelingService.Verify(r => r.Refuel(It.IsAny<string>()), Times.Exactly(2));

        _mockDiningService.Verify(d => d.ServeDinner(It.Is<string>(id => id == "1")), Times.Once);
        _mockDiningService.Verify(d => d.ServeDinner(It.Is<string>(id => id == "9")), Times.Never);
    }
}
