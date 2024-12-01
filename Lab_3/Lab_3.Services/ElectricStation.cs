using Lab_3.Domain;

namespace Lab_3.Services;

public class ElectricStation : IRefuelable
{
    private static int _electricCarsServed = 0;

    public void Refuel(string carId)
    {
        _electricCarsServed++;
        Console.WriteLine($"Refueling electric car {carId}.");
    }

    public static int GetElectricCarsServedCount() => _electricCarsServed;
}