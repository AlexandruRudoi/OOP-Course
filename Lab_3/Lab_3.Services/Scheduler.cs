using System.Threading;
using Lab_3.Domain.Utils;

namespace Lab_3.Services
{
    public class Scheduler
    {
        private readonly Semaphore _semaphore;
        private readonly string _queueFolderPath;
        private readonly int _readIntervalSeconds;
        private readonly int _serveIntervalSeconds;
        private readonly object _lockObject = new();

        /// <summary>
        ///     Initializes a new instance of the <see cref="Scheduler"/> class.
        /// </summary>
        /// <param name="semaphore">The semaphore to manage car stations.</param>
        /// <param name="queueFolderPath">The path to the folder containing car JSON files.</param>
        /// <param name="readIntervalSeconds">The interval (in seconds) for reading cars.</param>
        /// <param name="serveIntervalSeconds">The interval (in seconds) for serving cars.</param>
        public Scheduler(Semaphore semaphore, string queueFolderPath, int readIntervalSeconds, int serveIntervalSeconds)
        {
            _semaphore = semaphore;
            _queueFolderPath = queueFolderPath;
            _readIntervalSeconds = readIntervalSeconds;
            _serveIntervalSeconds = serveIntervalSeconds;
        }

        /// <summary>
        ///     Starts the scheduler by running tasks for reading and serving cars.
        /// </summary>
        public void Start()
        {
            // Start reader and server tasks
            var readerThread = new Thread(ReadFromQueueFolder);
            var serverThread = new Thread(ServeCars);

            readerThread.Start();
            serverThread.Start();

            readerThread.Join();
            serverThread.Join();
        }

        /// <summary>
        ///     Reads car data from the queue folder at regular intervals and dispatches the cars to the appropriate
        ///     car stations using the semaphore.
        /// </summary>
        private void ReadFromQueueFolder()
        {
            while (true)
            {
                try
                {
                    var cars = FileReader.ReadAndConvertAllCars(_queueFolderPath);

                    foreach (var car in cars)
                    {
                        lock (_lockObject)
                        {
                            _semaphore.DispatchCar(car);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading from queue folder: {ex.Message}");
                }

                Thread.Sleep(_readIntervalSeconds * 1000);
            }
        }

        /// <summary>
        ///     Serves cars from the car stations at regular intervals by invoking the semaphore's ServeAllCars method.
        /// </summary>
        private void ServeCars()
        {
            while (true)
            {
                try
                {
                    lock (_lockObject)
                    {
                        _semaphore.ServeAllCars();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error serving cars: {ex.Message}");
                }

                Thread.Sleep(_serveIntervalSeconds * 1000);
            }
        }
    }
}