using Lab_3.Domain;
using Newtonsoft.Json;

namespace Lab_3.Services;

public class Statistics
{
    private static int _totalPeopleServed = 0;
    private static int _totalRobotsServed = 0;
    private static int _totalElectricConsumption = 0;
    private static int _totalGasConsumption = 0;

    private static int _electricCarsServed = 0;
    private static int _gasCarsServed = 0;

    private static int _diningCount = 0;
    private static int _notDiningCount = 0;

    /// <summary>
    /// Updates statistics based on the car's attributes.
    /// </summary>
    /// <param name="car">The car being processed.</param>
    public static void AddToStatistics(Car car)
    {
        if (car.Passengers == "PEOPLE")
        {
            _totalPeopleServed++;
        }
        else if (car.Passengers == "ROBOTS")
        {
            _totalRobotsServed++;
        }

        if (car.Type == "ELECTRIC")
        {
            _electricCarsServed++;
            _totalElectricConsumption += car.Consumption;
        }
        else if (car.Type == "GAS")
        {
            _gasCarsServed++;
            _totalGasConsumption += car.Consumption;
        }

        if (car.IsDining)
        {
            _diningCount++;
        }
        else
        {
            _notDiningCount++;
        }
    }

    /// <summary>
    /// Generates a JSON-like string containing the aggregated statistics.
    /// </summary>
    /// <returns>A JSON-formatted string representing the statistics.</returns>
    public static string GenerateStatisticsJson()
    {
        var stats = new
        {
            ELECTRIC = _electricCarsServed,
            GAS = _gasCarsServed,
            PEOPLE = _totalPeopleServed,
            ROBOTS = _totalRobotsServed,
            DINING = _diningCount,
            NOT_DINING = _notDiningCount,
            CONSUMPTION = new
            {
                ELECTRIC = _totalElectricConsumption,
                GAS = _totalGasConsumption
            }
        };

        return JsonConvert.SerializeObject(stats, Formatting.Indented);
    }
}