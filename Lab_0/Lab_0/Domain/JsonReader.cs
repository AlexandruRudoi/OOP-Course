using System.Text.Json;

namespace Lab_0.Domain;

public class JsonReader
{
    public List<AlienSpecies> ReadJsonIntoAlienList(string filePath)
    {
        try
        {
            var jsonString = File.ReadAllText(filePath);

            using (var document = JsonDocument.Parse(jsonString))
            {
                // Get the root element (the object containing the "input" array)
                var root = document.RootElement;
                var inputArray = root.GetProperty("input");

                // Deserialize the "input" array into a List<AlienSpecies>
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var alienSpeciesList = JsonSerializer.Deserialize<List<AlienSpecies>>(inputArray.GetRawText(), options);

                return alienSpeciesList;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading JSON file: {ex.Message}");
            return null;
        }
    }
}