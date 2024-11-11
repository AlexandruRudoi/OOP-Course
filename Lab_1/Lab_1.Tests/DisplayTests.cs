using Lab_1.Domain;

namespace Lab_1.Tests;

[TestFixture]
public class DisplayTests
{
    private Display _display1;
    private Display _display2;
    private Display _display3;

    [SetUp]
    public void SetUp()
    {
        _display1 = new Display(1920, 1080, 401.5f, "Display One");
        _display2 = new Display(2560, 1440, 350.0f, "Display Two");
        _display3 = new Display(3840, 2160, 500.0f, "Display Three");
    }

    [Test]
    public void CompareSize_DisplayOneIsSmallerThanDisplayTwo_ReturnsCorrectOutput()
    {
        // Redirect output to capture console output
        using var sw = new StringWriter();
        Console.SetOut(sw);

        _display1.CompareSize(_display2);

        var expectedOutput = "Display One is smaller in size than Display Two.";
        Assert.IsTrue(sw.ToString().Trim().Contains(expectedOutput));
    }

    [Test]
    public void CompareSize_DisplayThreeIsBiggerThanDisplayTwo_ReturnsCorrectOutput()
    {
        using var sw = new StringWriter();
        Console.SetOut(sw);

        _display3.CompareSize(_display2);

        var expectedOutput = "Display Three is bigger in size than Display Two.";
        Assert.IsTrue(sw.ToString().Trim().Contains(expectedOutput));
    }

    [Test]
    public void CompareSize_SameDimensions_ReturnsEqualSizeOutput()
    {
        var identicalDisplay = new Display(1920, 1080, 401.5f, "Display Clone");
        using var sw = new StringWriter();
        Console.SetOut(sw);

        _display1.CompareSize(identicalDisplay);

        var expectedOutput = "Display One and Display Clone are equal in size.";
        Assert.IsTrue(sw.ToString().Trim().Contains(expectedOutput));
    }

    [Test]
    public void CompareSharpness_DisplayOneIsSharperThanDisplayTwo_ReturnsCorrectOutput()
    {
        using var sw = new StringWriter();
        Console.SetOut(sw);

        _display1.CompareSharpness(_display2);

        var expectedOutput = "Display One is sharper than Display Two.";
        Assert.IsTrue(sw.ToString().Trim().Contains(expectedOutput));
    }

    [Test]
    public void CompareSharpness_DisplayTwoIsLessSharpThanDisplayThree_ReturnsCorrectOutput()
    {
        using var sw = new StringWriter();
        Console.SetOut(sw);

        _display2.CompareSharpness(_display3);

        var expectedOutput = "Display Two is less sharp than Display Three.";
        Assert.IsTrue(sw.ToString().Trim().Contains(expectedOutput));
    }

    [Test]
    public void CompareSharpness_SamePpi_ReturnsEqualSharpnessOutput()
    {
        var identicalDisplay = new Display(1920, 1080, 401.5f, "Display Clone");
        using var sw = new StringWriter();
        Console.SetOut(sw);

        _display1.CompareSharpness(identicalDisplay);

        var expectedOutput = "Display One and Display Clone have the same sharpness.";
        Assert.IsTrue(sw.ToString().Trim().Contains(expectedOutput));
    }

    [Test]
    public void CompareWithMonitor_DisplayThreeVsDisplayOne_ReturnsDetailedComparison()
    {
        using var sw = new StringWriter();
        Console.SetOut(sw);

        _display3.CompareWithMonitor(_display1);

        var output = sw.ToString().Trim().Replace("\r\n", "\n");

        Assert.IsTrue(output.Contains("Comparing Display Three with Display One:"),
            "Failed to match comparison header.");
        Assert.IsTrue(output.Contains("Display Three is bigger in size than Display One."),
            "Failed to match size comparison.");
        Assert.IsTrue(output.Contains("Display Three is sharper than Display One."),
            "Failed to match sharpness comparison.");
    }
}