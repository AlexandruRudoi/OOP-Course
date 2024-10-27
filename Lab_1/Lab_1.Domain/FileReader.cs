namespace Lab_1.Domain;

public class FileReader
{
    /// <summary>
    /// Reads the contents of a text file at the specified path and returns it as a single string.
    /// </summary>
    /// <param name="filePath">The file path of the text file to be read.</param>
    /// <returns>
    /// A string containing the file's content if successful; otherwise, null if an error occurs.
    /// </returns>
    /// <exception cref="IOException">Thrown when an I/O error occurs while opening the file.</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown when the file path is inaccessible due to security restrictions.</exception>
    /// <remarks>
    /// This method will print an error message to the console if an exception occurs.
    /// </remarks>
    public string ReadFileIntoString(string filePath)
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