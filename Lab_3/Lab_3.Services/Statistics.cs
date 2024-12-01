namespace Lab_3.Services;

public class Statistics
{
    public static int GetTotalPeopleServed() => PeopleDinner.GetPeopleServedCount();
    public static int GetTotalRobotsServed() => RobotDinner.GetRobotsServedCount();
    public static int GetTotalElectricCarsServed() => ElectricStation.GetElectricCarsServedCount();
    public static int GetTotalGasCarsServed() => GasStation.GetGasCarsServedCount();
}