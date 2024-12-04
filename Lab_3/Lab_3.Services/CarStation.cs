using Lab_3.Domain;

namespace Lab_3.Services;

public class CarStation
{
    private readonly IDineable _diningService;
    private readonly IRefuelable _refuelingService;
    private readonly IQueue<Car> _queue;

    /// <summary>
    ///     Initializes a new instance of the <see cref="CarStation" /> class.
    /// </summary>
    /// <param name="diningService">The dining service for passengers.</param>
    /// <param name="refuelingService">The refueling service for cars.</param>
    /// <param name="queue">The queue to manage cars at the station.</param>
    public CarStation(IDineable diningService, IRefuelable refuelingService, IQueue<Car> queue)
    {
        _diningService = diningService;
        _refuelingService = refuelingService;
        _queue = queue;
    }

    /// <summary>
    ///     Adds a car to the station's queue.
    /// </summary>
    /// <param name="car">The car to add to the queue.</param>
    public void AddCar(Car car)
    {
        _queue.Enqueue(car);
    }

    /// <summary>
    ///     Serves all cars in the station's queue by providing dining and refueling services.
    /// </summary>
    public void ServeCars()
    {
        while (!_queue.IsEmpty())
        {
            var car = _queue.Dequeue();

            Statistics.AddToStatistics(car);

            if (car.IsDining)
            {
                _diningService.ServeDinner(car.Id);
            }

            _refuelingService.Refuel(car.Id);
        }
    }

    /// <summary>
    ///     Gets the number of cars currently in the station's queue.
    /// </summary>
    public int QueueCount()
    {
        return _queue.Count;
    }
}