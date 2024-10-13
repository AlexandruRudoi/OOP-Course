using System.Text.Json;

namespace Lab_0.Domain;


public class JsonReader
{
    public List<AlienSpecies> ReadJson(string filePath)
    {
        try
        {
            string jsonString = File.ReadAllText(filePath);
            
            using (JsonDocument document = JsonDocument.Parse(jsonString))
            {
                // Get the root element (the object containing the "input" array)
                JsonElement root = document.RootElement;
                JsonElement inputArray = root.GetProperty("input");

                // Deserialize the "input" array into a List<AlienSpecies>
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                List<AlienSpecies> alienSpeciesList = JsonSerializer.Deserialize<List<AlienSpecies>>(inputArray.GetRawText(), options);

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