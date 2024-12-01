using Lab_3.Domain;

namespace Lab_3.Services;

public class CarStation
{
    private readonly IDineable _peopleDiningService;
    private readonly IDineable _robotDiningService;
    private readonly IRefuelable _refuelingService;
    private readonly IQueue<Car> _queue;

    public CarStation(IDineable peopleDiningService, IDineable robotDiningService, IRefuelable refuelingService,
        IQueue<Car> queue)
    {
        _peopleDiningService = peopleDiningService;
        _robotDiningService = robotDiningService;
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
                if (car.Passengers == "PEOPLE")
                {
                    _peopleDiningService.ServeDinner(car.Id);
                }
                else if (car.Passengers == "ROBOTS")
                {
                    _robotDiningService.ServeDinner(car.Id);
                }
                else
                {
                    Console.WriteLine($"Unknown passenger type {car.Passengers} for car {car.Id}");
                }
            }

            _refuelingService.Refuel(car.Id);
        }
    }

    public int QueueCount() => _queue.Count;
}