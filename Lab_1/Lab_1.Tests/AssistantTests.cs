using Lab_1.Domain;

namespace Lab_1.Tests;

[TestFixture]
public class AssistantTests
{
    private Assistant _assistant;
    private Display _display1;
    private Display _display2;
    private Display _display3;
    private TextWriter _originalConsoleOut;

    [SetUp]
    public void SetUp()
    {
        _assistant = new Assistant("Tech Assistant");
        _display1 = new Display(1920, 1080, 401.5f, "Display One");
        _display2 = new Display(2560, 1440, 350.0f, "Display Two");
        _display3 = new Display(3840, 2160, 500.0f, "Display Three");

        // Capture the original Console.Out
        _originalConsoleOut = Console.Out;
    }

    [TearDown]
    public void TearDown()
    {
        Console.SetOut(_originalConsoleOut);
    }

    [Test]
    public void AssignDisplay_AddsDisplayToList()
    {
        using var sw = new StringWriter();
        Console.SetOut(sw);

        _assistant.AssignDisplay(_display1);

        var output = sw.ToString().Trim();
        Assert.IsTrue(output.Contains("Display One has been assigned to Tech Assistant."));
    }

    [Test]
    public void Assist_LessThanTwoDisplays_PrintsNotEnoughDisplaysMessage()
    {
        using var sw = new StringWriter();
        Console.SetOut(sw);

        _assistant.AssignDisplay(_display1);
        _assistant.Assist();

        var output = sw.ToString().Trim();
        Assert.IsTrue(output.Contains("Not enough displays to compare."));
    }

    [Test]
    public void Assist_MultipleDisplays_OutputsComparison()
    {
        using var sw = new StringWriter();
        Console.SetOut(sw);

        _assistant.AssignDisplay(_display1);
        _assistant.AssignDisplay(_display2);
        _assistant.AssignDisplay(_display3);

        _assistant.Assist();

        var output = sw.ToString().Trim();
        Assert.IsTrue(output.Contains("Assistant Tech Assistant is helping with display comparison:"));
        Assert.IsTrue(output.Contains("Display One is smaller in size than Display Two."));
        Assert.IsTrue(output.Contains("Display Two is smaller in size than Display Three."));
    }

    [Test]
    public void BuyDisplay_DisplayExists_RemovesAndReturnsDisplay()
    {
        _assistant.AssignDisplay(_display1);
        _assistant.AssignDisplay(_display2);

        using var sw = new StringWriter();
        Console.SetOut(sw);

        var result = _assistant.BuyDisplay(_display1);

        Assert.That(result, Is.EqualTo(_display1));
        var output = sw.ToString().Trim();
        Assert.IsTrue(
            output.Contains("Display One has been bought and removed from Tech Assistant's assigned displays."));
    }

    [Test]
    public void BuyDisplay_DisplayDoesNotExist_ReturnsNullAndPrintsMessage()
    {
        using var sw = new StringWriter();
        Console.SetOut(sw);

        var result = _assistant.BuyDisplay(_display1);

        Assert.IsNull(result);
        var output = sw.ToString().Trim();
        Assert.IsTrue(output.Contains("Display One could not be found in Tech Assistant's assigned displays."));
    }
}