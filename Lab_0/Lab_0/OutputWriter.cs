using System.Text.Json;
using Lab_0.Domain;

namespace Lab_0;

public class OutputWriter
{
    public void WriteToFile(string fileName, string universeName, List<AlienSpecies> individuals)
    {
        var outputDirectory = "../../../output";
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        var universeOutput = new
        {
            name = universeName,
            individuals = individuals
        };

        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(universeOutput, options);

        // Write the output to a JSON file
        File.WriteAllText(Path.Combine(outputDirectory, fileName), jsonString);

        Console.WriteLine($"{fileName} has been written with {individuals.Count} individuals.");
    }
}