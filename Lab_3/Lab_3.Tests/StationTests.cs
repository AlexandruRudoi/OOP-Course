using System.Reflection;
using Lab_3.Domain;
using Lab_3.Services;

namespace Lab_3.Tests;

public class StationTests
{
    private ElectricStation _electricStation;
    private GasStation _gasStation;
    private PeopleDinner _peopleDinner;
    private RobotDinner _robotDinner;

    [SetUp]
    public void Setup()
    {
        // Reset static counters for dining services
        typeof(PeopleDinner).GetField("_peopleServed",
            BindingFlags.NonPublic | BindingFlags.Static)?.SetValue(null, 0);
        typeof(RobotDinner).GetField("_robotsServed",
            BindingFlags.NonPublic | BindingFlags.Static)?.SetValue(null, 0);

        // Reset static counters for refueling services
        typeof(ElectricStation).GetField("_electricCarsServed",
            BindingFlags.NonPublic | BindingFlags.Static)?.SetValue(null, 0);
        typeof(GasStation).GetField("_gasCarsServed",
            BindingFlags.NonPublic | BindingFlags.Static)?.SetValue(null, 0);

        // Reset static counters for statistics
        typeof(Statistics).GetField("_totalPeopleServed",
            BindingFlags.NonPublic | BindingFlags.Static)?.SetValue(null, 0);
        typeof(Statistics).GetField("_totalRobotsServed",
            BindingFlags.NonPublic | BindingFlags.Static)?.SetValue(null, 0);
        typeof(Statistics).GetField("_totalElectricConsumption",
            BindingFlags.NonPublic | BindingFlags.Static)?.SetValue(null, 0);
        typeof(Statistics).GetField("_totalGasConsumption",
            BindingFlags.NonPublic | BindingFlags.Static)?.SetValue(null, 0);
        typeof(Statistics).GetField("_electricCarsServed",
            BindingFlags.NonPublic | BindingFlags.Static)?.SetValue(null, 0);
        typeof(Statistics).GetField("_gasCarsServed",
            BindingFlags.NonPublic | BindingFlags.Static)?.SetValue(null, 0);
        typeof(Statistics).GetField("_diningCount",
            BindingFlags.NonPublic | BindingFlags.Static)?.SetValue(null, 0);
        typeof(Statistics).GetField("_notDiningCount",
            BindingFlags.NonPublic | BindingFlags.Static)?.SetValue(null, 0);

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
        // Add cars to simulate processing
        var car1 = new Car("Car1", "ELECTRIC", "PEOPLE", true, 50);
        var car2 = new Car("Car2", "GAS", "ROBOTS", false, 40);
        var car3 = new Car("Car3", "ELECTRIC", "ROBOTS", true, 30);
        var car4 = new Car("Car4", "GAS", "PEOPLE", false, 20);

        Statistics.AddToStatistics(car1);
        Statistics.AddToStatistics(car2);
        Statistics.AddToStatistics(car3);
        Statistics.AddToStatistics(car4);

        var expectedJson = @"{
  ""ELECTRIC"": 2,
  ""GAS"": 2,
  ""PEOPLE"": 2,
  ""ROBOTS"": 2,
  ""DINING"": 2,
  ""NOT_DINING"": 2,
  ""CONSUMPTION"": {
    ""ELECTRIC"": 80,
    ""GAS"": 60
  }
}";

        var actualJson = Statistics.GenerateStatisticsJson();
        Assert.That(actualJson, Is.EqualTo(expectedJson));
    }
}