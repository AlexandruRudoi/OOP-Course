using Lab_3.Domain;

namespace Lab_3.Services;

public class RobotDinner : IDineable
{
    private static int _robotsServed = 0;

    /// <inheritdoc />
    public void ServeDinner(string carId)
    {
        _robotsServed++;
        Console.WriteLine($"Serving dinner to robots in car {carId}.");
    }

    public static int GetRobotsServedCount()
    {
        return _robotsServed;
    }
}