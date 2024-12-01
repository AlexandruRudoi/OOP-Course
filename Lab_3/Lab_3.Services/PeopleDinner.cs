using Lab_3.Domain;

namespace Lab_3.Services;

public class PeopleDinner : IDineable
{
    private static int _peopleServed = 0;

    /// <inheritdoc/>
    public void ServeDinner(string carId)
    {
        _peopleServed++;
        Console.WriteLine($"Serving dinner to people in car {carId}.");
    }

    public static int GetPeopleServedCount() => _peopleServed;
}