using Lab_3.Services;

namespace Lab_3.Tests
{
    public class StationTests
    {
        private PeopleDinner _peopleDinner;
        private RobotDinner _robotDinner;
        private ElectricStation _electricStation;
        private GasStation _gasStation;

        [SetUp]
        public void Setup()
        {
            // Reset static counters
            typeof(PeopleDinner).GetField("_peopleServed",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)?.SetValue(null, 0);
            typeof(RobotDinner).GetField("_robotsServed",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)?.SetValue(null, 0);
            typeof(ElectricStation).GetField("_electricCarsServed",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)?.SetValue(null, 0);
            typeof(GasStation).GetField("_gasCarsServed",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)?.SetValue(null, 0);

            // Reinitialize services
            _peopleDinner = new PeopleDinner();
            _robotDinner = new RobotDinner();
            _electricStation = new ElectricStation();
            _gasStation = new GasStation();
        }

        [Test]
        public void ServeDinner_CarWithPeople_LogsCorrectly()
        {
            _peopleDinner.ServeDinner("Car1");
            Assert.That(PeopleDinner.GetPeopleServedCount(), Is.EqualTo(1));
        }

        [Test]
        public void ServeDinner_CarWithRobots_LogsCorrectly()
        {
            _robotDinner.ServeDinner("Car2");
            Assert.That(RobotDinner.GetRobotsServedCount(), Is.EqualTo(1));
        }

        [Test]
        public void Refuel_ElectricCar_LogsCorrectly()
        {
            _electricStation.Refuel("Car3");
            Assert.That(ElectricStation.GetElectricCarsServedCount(), Is.EqualTo(1));
        }

        [Test]
        public void Refuel_GasCar_LogsCorrectly()
        {
            _gasStation.Refuel("Car4");
            Assert.That(GasStation.GetGasCarsServedCount(), Is.EqualTo(1));
        }

        [Test]
        public void Statistics_CombinedStations_CorrectCounts()
        {
            _peopleDinner.ServeDinner("Car1");
            _robotDinner.ServeDinner("Car2");
            _electricStation.Refuel("Car3");
            _gasStation.Refuel("Car4");

            Assert.That(Statistics.GetTotalPeopleServed(), Is.EqualTo(1));
            Assert.That(Statistics.GetTotalRobotsServed(), Is.EqualTo(1));
            Assert.That(Statistics.GetTotalElectricCarsServed(), Is.EqualTo(1));
            Assert.That(Statistics.GetTotalGasCarsServed(), Is.EqualTo(1));
        }
    }
}