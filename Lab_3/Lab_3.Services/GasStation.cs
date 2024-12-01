using Lab_3.Domain;

namespace Lab_3.Services;

public class GasStation : IRefuelable
{
    private static int _gasCarsServed = 0;

    /// <inheritdoc />
    public void Refuel(string carId)
    {
        _gasCarsServed++;
        Console.WriteLine($"Refueling gas car {carId}.");
    }

    public static int GetGasCarsServedCount()
    {
        return _gasCarsServed;
    }
}