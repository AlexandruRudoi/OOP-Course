namespace Lab_1;

public class FileReader
{
    public string? ReadFileIntoString(string filePath)
    {
        try
        {
            return File.ReadAllText(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
            return null;
        }
    }
}