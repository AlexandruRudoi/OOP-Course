namespace Lab_3.Services;

public class Statistics
{
    /// <summary>
    ///     Gets the total number of people served by dining services.
    /// </summary>
    /// <returns>The total count of people served.</returns>
    public static int GetTotalPeopleServed() => PeopleDinner.GetPeopleServedCount();

    /// <summary>
    ///     Gets the total number of robots served by dining services.
    /// </summary>
    /// <returns>The total count of robots served.</returns>
    public static int GetTotalRobotsServed() => RobotDinner.GetRobotsServedCount();

    /// <summary>
    ///     Gets the total number of electric cars served by refueling services.
    /// </summary>
    /// <returns>The total count of electric cars served.</returns>
    public static int GetTotalElectricCarsServed() => ElectricStation.GetElectricCarsServedCount();

    /// <summary>
    ///     Gets the total number of gas cars served by refueling services.
    /// </summary>
    /// <returns>The total count of gas cars served.</returns>
    public static int GetTotalGasCarsServed() => GasStation.GetGasCarsServedCount();
}