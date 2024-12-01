namespace Lab_3.Domain.Utils;

public static class FileReader
{
    /// <summary>
    ///     Reads all JSON files from the specified folder and converts them to Car objects.
    /// </summary>
    /// <param name="folderPath">The path to the folder containing JSON files.</param>
    /// <returns>A list of Car objects representing the parsed file contents.</returns>
    public static List<Car> ReadAndConvertAllCars(string folderPath)
    {
        var cars = new List<Car>();

        try
        {
            if (!Directory.Exists(folderPath))
            {
                throw new DirectoryNotFoundException($"Folder not found: {folderPath}");
            }

            var files = Directory.GetFiles(folderPath, "*.json");

            foreach (var file in files)
            {
                try
                {
                    var jsonContent = File.ReadAllText(file);
                    var car = CarParser.ParseFromJson(jsonContent);

                    if (car != null)
                    {
                        cars.Add(car);
                    }

                    File.Delete(file); // Clean up after processing
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading or converting file {file}: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error accessing folder {folderPath}: {ex.Message}");
        }

        return cars;
    }
}