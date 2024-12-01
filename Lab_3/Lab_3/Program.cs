using Lab_3.Domain;
using Lab_3.Repositories;
using Lab_3.Services;
using Semaphore = Lab_3.Services.Semaphore;

namespace Lab_3;

internal class Program
{
    private static void Main(string[] args)
    {
        var electricStation = new CarStation(new PeopleDinner(), new RobotDinner(), new ElectricStation(),
            new LinkedListQueue<Car>());
        var gasStation = new CarStation(new PeopleDinner(), new RobotDinner(), new GasStation(), new ArrayQueue<Car>());

        var semaphore = new Semaphore(electricStation, gasStation);

        // Define the queue folder path
        var queueFolderPath = args[0];

        var scheduler = new Scheduler(semaphore, queueFolderPath, 5, 10);
        scheduler.Start();
    }
}