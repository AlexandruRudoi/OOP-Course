using Lab_2.Task4;

namespace Lab_2.Tests;

[TestFixture]
public class BaristaTests
{
    private Barista _barista;
    private TextWriter _originalConsoleOut;

    [SetUp]
    public void Setup()
    {
        _barista = new Barista();
        _originalConsoleOut = Console.Out; // Save the original Console.Out
    }

    [TearDown]
    public void TearDown()
    {
        Console.SetOut(_originalConsoleOut); // Restore the original Console.Out after each test
    }

    [Test]
    public void TakeOrder_PreparesCoffeesCorrectly()
    {
        // Arrange
        var orders =
            new List<(string CoffeeType, Intensity Intensity, int? MlOfMilk, int? MgOfPumpkinSpice, SyrupType? Syrup)>
            {
                ("Cappuccino", Intensity.NORMAL, 50, null, null),
                ("PumpkinSpiceLatte", Intensity.STRONG, 100, 10, null),
                ("Americano", Intensity.LIGHT, 200, null, null),
                ("SyrupCappuccino", Intensity.NORMAL, 150, null, SyrupType.VANILLA)
            };

        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            _barista.TakeOrder(orders);

            // Capture the result for assertion
            var result = sw.ToString();

            // Assert each coffee preparation output
            Assert.IsTrue(result.Contains("Making Cappuccino", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(result.Contains("Intensity set to NORMAL", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(result.Contains("Adding 50 mls of milk", StringComparison.OrdinalIgnoreCase));

            Assert.IsTrue(result.Contains("Making PumpkinSpiceLatte", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(result.Contains("Intensity set to STRONG", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(result.Contains("Adding 100 mls of milk", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(result.Contains("Adding 10 mls of pumpkin spice", StringComparison.OrdinalIgnoreCase));

            Assert.IsTrue(result.Contains("Making Americano", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(result.Contains("Intensity set to LIGHT", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(result.Contains("Adding 200 mls of water", StringComparison.OrdinalIgnoreCase));

            Assert.IsTrue(result.Contains("Making SyrupCappuccino", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(result.Contains("Intensity set to NORMAL", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(result.Contains("Adding 150 mls of milk", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(result.Contains("Adding VANILLA syrup", StringComparison.OrdinalIgnoreCase));
        }
    }
}