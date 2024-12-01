using Lab_3.Domain;

namespace Lab_3.Services;

public class Semaphore
{
    private readonly CarStation _electricCarStation;
    private readonly CarStation _gasCarStation;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Semaphore" /> class.
    /// </summary>
    /// <param name="electricCarStation">The car station that serves electric cars.</param>
    /// <param name="gasCarStation">The car station that serves gas cars.</param>
    public Semaphore(CarStation electricCarStation, CarStation gasCarStation)
    {
        _electricCarStation = electricCarStation;
        _gasCarStation = gasCarStation;
    }

    /// <summary>
    ///     Dispatches a car to the appropriate car station based on its type.
    /// </summary>
    /// <param name="car">The car to be dispatched.</param>
    public void DispatchCar(Car car)
    {
        if (car.Type == "ELECTRIC")
            _electricCarStation.AddCar(car);
        else if (car.Type == "GAS") _gasCarStation.AddCar(car);
    }

    /// <summary>
    ///     Serves all cars in both the electric and gas car stations.
    /// </summary>
    public void ServeAllCars()
    {
        _electricCarStation.ServeCars();
        _gasCarStation.ServeCars();
    }
}