using Lab_3.Domain;

namespace Lab_3.Services;

public class Semaphore
{
    private readonly CarStation _robotElectricStation;
    private readonly CarStation _robotGasStation;
    private readonly CarStation _peopleElectricStation;
    private readonly CarStation _peopleGasStation;

    /// <summary>
    ///     Initializes a new instance of the <see cref="Semaphore"/> class.
    /// </summary>
    /// <param name="robotElectricStation">The car station that serves electric cars with robots.</param>
    /// <param name="robotGasStation">The car station that serves gas cars with robots.</param>
    /// <param name="peopleElectricStation">The car station that serves electric cars with people.</param>
    /// <param name="peopleGasStation">The car station that serves gas cars with people.</param>
    public Semaphore(
        CarStation robotElectricStation,
        CarStation robotGasStation,
        CarStation peopleElectricStation,
        CarStation peopleGasStation)
    {
        _robotElectricStation = robotElectricStation;
        _robotGasStation = robotGasStation;
        _peopleElectricStation = peopleElectricStation;
        _peopleGasStation = peopleGasStation;
    }

    /// <summary>
    ///     Dispatches a car to the appropriate car station based on its type and passengers.
    /// </summary>
    /// <param name="car">The car to be dispatched.</param>
    public void DispatchCar(Car car)
    {
        if (car.Type == "ELECTRIC")
        {
            if (car.Passengers == "PEOPLE")
            {
                _peopleElectricStation.AddCar(car);
            }
            else if (car.Passengers == "ROBOTS")
            {
                _robotElectricStation.AddCar(car);
            }
        }
        else if (car.Type == "GAS")
        {
            if (car.Passengers == "PEOPLE")
            {
                _peopleGasStation.AddCar(car);
            }
            else if (car.Passengers == "ROBOTS")
            {
                _robotGasStation.AddCar(car);
            }
        }
    }
    
    /// <summary>
    ///     Serves all cars in all car stations.
    /// </summary>
    public void ServeAllCars()
    {
        _robotElectricStation.ServeCars();
        _robotGasStation.ServeCars();
        _peopleElectricStation.ServeCars();
        _peopleGasStation.ServeCars();
    }
}