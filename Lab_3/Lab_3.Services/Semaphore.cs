using Lab_3.Domain;

namespace Lab_3.Services;

public class Semaphore
{
    private readonly CarStation _electricCarStation;
    private readonly CarStation _gasCarStation;

    public Semaphore(CarStation electricCarStation, CarStation gasCarStation)
    {
        _electricCarStation = electricCarStation;
        _gasCarStation = gasCarStation;
    }

    public void DispatchCar(Car car)
    {
        if (car.Type == "ELECTRIC")
        {
            _electricCarStation.AddCar(car);
        }
        else if (car.Type == "GAS")
        {
            _gasCarStation.AddCar(car);
        }
    }

    public void ServeAllCars()
    {
        _electricCarStation.ServeCars();
        _gasCarStation.ServeCars();
    }
}