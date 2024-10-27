using Lab_1.Domain;

namespace Lab_1;

internal class Program
{
    private static void Main(string[] args)
    {
        var display1 = new Display(1920, 1080, 401.5f, "Display One");
        var display2 = new Display(2560, 1440, 350.0f, "Display Two");
        var display3 = new Display(3840, 2160, 500.0f, "Display Three");

        var assistant = new Assistant("Tech Assistant");
        assistant.AssignDisplay(display1);
        assistant.AssignDisplay(display2);
        assistant.AssignDisplay(display3);

        assistant.Assist();
        assistant.BuyDisplay(display2);

        // var filePath = args[0];
        // var fileReader = new FileReader();
        // var textContent = fileReader.ReadFileIntoString(filePath);
        //
        // if (textContent != null)
        // {
        //     var textData = new TextData(textContent, Path.GetFileName(filePath));
        //     Console.WriteLine(textData.ToString());
        // }
    }
}