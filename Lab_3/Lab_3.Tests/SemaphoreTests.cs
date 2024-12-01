using Lab_3.Domain;
using Lab_3.Services;
using Lab_3.Repositories;
using Lab_3.Domain.Utils;
using Semaphore = Lab_3.Services.Semaphore;
using Moq;

namespace Lab_3.Tests
{
    public class SemaphoreTests
    {
        private Semaphore _semaphore;
        private CarStation _electricCarStation;
        private CarStation _gasCarStation;
        private LinkedListQueue<Car> _electricQueue;
        private ArrayQueue<Car> _gasQueue;
        private Mock<IDineable> _mockPeopleDiningService;
        private Mock<IDineable> _mockRobotDiningService;
        private Mock<IRefuelable> _mockElectricRefuelingService;
        private Mock<IRefuelable> _mockGasRefuelingService;

        [SetUp]
        public void Setup()
        {
            // Mock dependencies
            _mockPeopleDiningService = new Mock<IDineable>();
            _mockRobotDiningService = new Mock<IDineable>();
            _mockElectricRefuelingService = new Mock<IRefuelable>();
            _mockGasRefuelingService = new Mock<IRefuelable>();

            // Create queues
            _electricQueue = new LinkedListQueue<Car>();
            _gasQueue = new ArrayQueue<Car>();

            // Create car stations
            _electricCarStation = new CarStation(
                _mockPeopleDiningService.Object,
                _mockRobotDiningService.Object,
                _mockElectricRefuelingService.Object,
                _electricQueue
            );

            _gasCarStation = new CarStation(
                _mockPeopleDiningService.Object,
                _mockRobotDiningService.Object,
                _mockGasRefuelingService.Object,
                _gasQueue
            );

            // Create semaphore
            _semaphore = new Semaphore(_electricCarStation, _gasCarStation);
        }

        [Test]
        public void DispatchCar_ElectricCar_AddedToElectricStation()
        {
            var json =
                "{\"id\": 5, \"type\": \"ELECTRIC\", \"passengers\": \"PEOPLE\", \"isDining\": false, \"consumption\": 49}";
            var car = CarParser.ParseFromJson(json);

            _semaphore.DispatchCar(car);

            Assert.That(_electricCarStation.QueueCount(), Is.EqualTo(1));
            Assert.That(_gasCarStation.QueueCount(), Is.EqualTo(0));
        }

        [Test]
        public void DispatchCar_GasCar_AddedToGasStation()
        {
            var json =
                "{\"id\": 2, \"type\": \"GAS\", \"passengers\": \"ROBOTS\", \"isDining\": true, \"consumption\": 42}";
            var car = CarParser.ParseFromJson(json);

            _semaphore.DispatchCar(car);

            Assert.That(_electricCarStation.QueueCount(), Is.EqualTo(0));
            Assert.That(_gasCarStation.QueueCount(), Is.EqualTo(1));
        }

        [Test]
        public void ServeAllCars_MultipleCars_AllServedCorrectly()
        {
            var carJsons = new[]
            {
                "{\"id\": 5, \"type\": \"ELECTRIC\", \"passengers\": \"PEOPLE\", \"isDining\": false, \"consumption\": 49}",
                "{\"id\": 2, \"type\": \"GAS\", \"passengers\": \"ROBOTS\", \"isDining\": true, \"consumption\": 42}",
                "{\"id\": 6, \"type\": \"ELECTRIC\", \"passengers\": \"ROBOTS\", \"isDining\": false, \"consumption\": 46}",
                "{\"id\": 8, \"type\": \"GAS\", \"passengers\": \"PEOPLE\", \"isDining\": true, \"consumption\": 25}"
            };

            foreach (var json in carJsons)
            {
                var car = CarParser.ParseFromJson(json);
                _semaphore.DispatchCar(car);
            }

            Assert.That(_electricCarStation.QueueCount(), Is.EqualTo(2));
            Assert.That(_gasCarStation.QueueCount(), Is.EqualTo(2));

            _semaphore.ServeAllCars();

            Assert.That(_electricCarStation.QueueCount(), Is.EqualTo(0));
            Assert.That(_gasCarStation.QueueCount(), Is.EqualTo(0));
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

            // Verify refueling
            _mockElectricRefuelingService.Verify(r => r.Refuel(It.IsAny<string>()), Times.Exactly(2));
            _mockGasRefuelingService.Verify(r => r.Refuel(It.IsAny<string>()), Times.Exactly(2));

            // Verify dining
            _mockPeopleDiningService.Verify(d => d.ServeDinner(It.Is<string>(id => id == "1")), Times.Once);
            _mockRobotDiningService.Verify(d => d.ServeDinner(It.IsAny<string>()), Times.Never);
        }
    }
}