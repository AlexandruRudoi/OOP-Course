using Lab_1.Domain;

namespace Lab_1;

internal class Program
{
    private static void Main(string[] args)
    {
        // Create three Display objects
        // Display display1 = new Display(1920, 1080, 401.5f, "Display One");
        // Display display2 = new Display(2560, 1440, 350.0f, "Display Two");
        // Display display3 = new Display(3840, 2160, 500.0f, "Display Three");

        // Compare displays
        // display1.CompareWithMonitor(display2);
        // display2.CompareWithMonitor(display3);
        // display1.CompareWithMonitor(display3);

        var filePath = args[0];
        var fileReader = new FileReader();
        var textContent = fileReader.ReadFileIntoString(filePath);

        if (textContent != null)
        {
            var textData = new TextData(textContent, Path.GetFileName(filePath));
            Console.WriteLine(textData.ToString());
        }
    }
}