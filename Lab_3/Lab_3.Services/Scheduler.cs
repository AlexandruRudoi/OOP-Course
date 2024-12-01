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

        public Scheduler(Semaphore semaphore, string queueFolderPath, int readIntervalSeconds, int serveIntervalSeconds)
        {
            _semaphore = semaphore;
            _queueFolderPath = queueFolderPath;
            _readIntervalSeconds = readIntervalSeconds;
            _serveIntervalSeconds = serveIntervalSeconds;
        }

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
