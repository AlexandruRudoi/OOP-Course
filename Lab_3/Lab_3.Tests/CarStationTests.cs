using Lab_3.Domain;
using Lab_3.Services;
using Lab_3.Repositories;
using Moq;

namespace Lab_3.Tests
{
    public class CarStationTests
    {
        private Mock<IDineable> _mockDiningService;
        private Mock<IRefuelable> _mockRefuelingService;
        private ArrayQueue<Car> _queue;
        private CarStation _carStation;

        [SetUp]
        public void Setup()
        {
            _mockDiningService = new Mock<IDineable>();
            _mockRefuelingService = new Mock<IRefuelable>();
            _queue = new ArrayQueue<Car>();
            _carStation = new CarStation(_mockDiningService.Object, _mockRefuelingService.Object, _queue);
        }

        [Test]
        public void ServeCars_SingleCarWithDiningAndRefueling_CallsBothServices()
        {
            var car = new Car("Car1", "ELECTRIC", "PEOPLE", true, 20);
            _carStation.AddCar(car);

            _carStation.ServeCars();

            _mockDiningService.Verify(d => d.ServeDinner("Car1"), Times.Once);
            _mockRefuelingService.Verify(r => r.Refuel("Car1"), Times.Once);
            Assert.IsTrue(_queue.IsEmpty());
        }

        [Test]
        public void ServeCars_SingleCarWithRefuelingOnly_CallsRefuelingServiceOnly()
        {
            var car = new Car("Car2", "GAS", "ROBOTS", false, 30);
            _carStation.AddCar(car);

            _carStation.ServeCars();

            _mockDiningService.Verify(d => d.ServeDinner(It.IsAny<string>()), Times.Never);
            _mockRefuelingService.Verify(r => r.Refuel("Car2"), Times.Once);
            Assert.IsTrue(_queue.IsEmpty());
        }

        [Test]
        public void ServeCars_MultipleCars_CallsServicesForEachCar()
        {
            var car1 = new Car("Car1", "ELECTRIC", "PEOPLE", true, 20);
            var car2 = new Car("Car2", "GAS", "ROBOTS", false, 30);
            _carStation.AddCar(car1);
            _carStation.AddCar(car2);

            _carStation.ServeCars();

            _mockDiningService.Verify(d => d.ServeDinner("Car1"), Times.Once);
            _mockRefuelingService.Verify(r => r.Refuel("Car1"), Times.Once);
            _mockDiningService.Verify(d => d.ServeDinner(It.Is<string>(id => id == "Car2")), Times.Never);
            _mockRefuelingService.Verify(r => r.Refuel("Car2"), Times.Once);
            Assert.IsTrue(_queue.IsEmpty());
        }
    }
}