using Lab_3.Domain;
using Lab_3.Repositories;
using Lab_3.Services;
using Moq;

namespace Lab_3.Tests;

public class CarStationTests
{
    private CarStation _carStation;
    private Mock<IDineable> _mockDiningService;
    private Mock<IRefuelable> _mockRefuelingService;
    private ArrayQueue<Car> _queue;

    [SetUp]
    public void Setup()
    {
        _mockDiningService = new Mock<IDineable>();
        _mockRefuelingService = new Mock<IRefuelable>();
        _queue = new ArrayQueue<Car>();
        _carStation = new CarStation(_mockDiningService.Object, _mockRefuelingService.Object, _queue);
    }

    [Test]
    public void ServeCars_SingleCarWithPeopleDiningAndRefueling_CallsCorrectServices()
    {
        var car = new Car("Car1", "ELECTRIC", "PEOPLE", true, 20);
        _carStation.AddCar(car);

        _carStation.ServeCars();

        _mockDiningService.Verify(d => d.ServeDinner("Car1"), Times.Once);
        _mockRefuelingService.Verify(r => r.Refuel("Car1"), Times.Once);
        Assert.IsTrue(_queue.IsEmpty());
    }

    [Test]
    public void ServeCars_SingleCarWithRobotDiningAndRefueling_CallsCorrectServices()
    {
        var car = new Car("Car2", "GAS", "ROBOTS", true, 30);
        _carStation.AddCar(car);

        _carStation.ServeCars();

        _mockDiningService.Verify(d => d.ServeDinner("Car2"), Times.Once);
        _mockRefuelingService.Verify(r => r.Refuel("Car2"), Times.Once);
        Assert.IsTrue(_queue.IsEmpty());
    }


    [Test]
    public void ServeCars_SingleCarWithRefuelingOnly_CallsRefuelingServiceOnly()
    {
        var car = new Car("Car3", "ELECTRIC", "PEOPLE", false, 30);
        _carStation.AddCar(car);

        _carStation.ServeCars();

        _mockDiningService.Verify(d => d.ServeDinner(It.IsAny<string>()), Times.Never);
        _mockRefuelingService.Verify(r => r.Refuel("Car3"), Times.Once);
        Assert.IsTrue(_queue.IsEmpty());
    }

    [Test]
    public void ServeCars_MultipleCars_CallsCorrectServicesForEachCar()
    {
        var car1 = new Car("Car1", "ELECTRIC", "PEOPLE", true, 20);
        var car2 = new Car("Car2", "GAS", "ROBOTS", true, 30);
        var car3 = new Car("Car3", "GAS", "PEOPLE", false, 40);

        _carStation.AddCar(car1);
        _carStation.AddCar(car2);
        _carStation.AddCar(car3);

        _carStation.ServeCars();

        _mockDiningService.Verify(d => d.ServeDinner("Car1"), Times.Once);
        _mockDiningService.Verify(d => d.ServeDinner("Car2"), Times.Once);
        _mockDiningService.Verify(d => d.ServeDinner(It.Is<string>(id => id == "Car3")), Times.Never);
        _mockRefuelingService.Verify(r => r.Refuel(It.IsAny<string>()), Times.Exactly(3));
        Assert.IsTrue(_queue.IsEmpty());
    }
}