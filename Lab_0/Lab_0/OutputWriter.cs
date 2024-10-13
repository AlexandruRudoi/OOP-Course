using System.Text.Json;
using Lab_0.Domain;

namespace Lab_0;

public class OutputWriter
{
    /// <summary>
    ///     Writes the list of classified individuals to a JSON file in the specified output directory.
    /// </summary>
    /// <param name="fileName">The name of the output file to write (e.g., "hitchhiker.json").</param>
    /// <param name="universeName">The name of the fictional universe (e.g., "hitchHiker", "marvel").</param>
    /// <param name="individuals">A list of AlienSpecies objects representing the individuals to write to the file.</param>
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