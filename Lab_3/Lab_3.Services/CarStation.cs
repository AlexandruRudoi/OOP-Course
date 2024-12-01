using Lab_3.Domain;

namespace Lab_3.Services;

public class CarStation
{
    private readonly IDineable _diningService;
    private readonly IRefuelable _refuelingService;
    private readonly IQueue<Car> _queue;

    public CarStation(IDineable diningService, IRefuelable refuelingService, IQueue<Car> queue)
    {
        _diningService = diningService;
        _refuelingService = refuelingService;
        _queue = queue;
    }

    public void AddCar(Car car)
    {
        _queue.Enqueue(car);
    }

    public void ServeCars()
    {
        while (!_queue.IsEmpty())
        {
            Car car = _queue.Dequeue();

            if (car.IsDining)
            {
                _diningService.ServeDinner(car.Id);
            }

            _refuelingService.Refuel(car.Id);
        }
    }

    public int QueueCount() => _queue.Count;
}