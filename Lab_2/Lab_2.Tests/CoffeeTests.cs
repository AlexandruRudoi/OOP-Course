using Lab_2.Task3;

namespace Lab_2.Tests;

[TestFixture]
public class CoffeeTests
{
    [Test]
    public void Cappuccino_MakeCoffee_CorrectOutput()
    {
        // Arrange
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            var cappuccino = Cappuccino.MakeCappuccino(Intensity.NORMAL, 50);

            // Assert
            var result = sw.ToString();
            Assert.IsTrue(result.Contains("Making Cappuccino"));
            Assert.IsTrue(result.Contains("Intensity set to NORMAL"));
            Assert.IsTrue(result.Contains("Adding 50 mls of milk"));
        }
    }

    [Test]
    public void PumpkinSpiceLatte_MakeCoffee_CorrectOutput()
    {
        // Arrange
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            var pumpkinLatte = PumpkinSpiceLatte.MakePumpkinSpiceLatte(Intensity.STRONG, 100, 10);

            // Assert
            var result = sw.ToString();
            Assert.IsTrue(result.Contains("Making PumpkinSpiceLatte"));
            Assert.IsTrue(result.Contains("Intensity set to STRONG"));
            Assert.IsTrue(result.Contains("Adding 100 mls of milk"));
            Assert.IsTrue(result.Contains("Adding 10 mls of pumpkin spice"));
        }
    }

    [Test]
    public void Americano_MakeCoffee_CorrectOutput()
    {
        // Arrange
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            var americano = Americano.MakeAmericano(Intensity.LIGHT, 200);

            // Assert
            var result = sw.ToString();
            Assert.IsTrue(result.Contains("Making Americano"));
            Assert.IsTrue(result.Contains("Intensity set to LIGHT"));
            Assert.IsTrue(result.Contains("Adding 200 mls of water"));
        }
    }

    [Test]
    public void SyrupCappuccino_MakeCoffee_CorrectOutput()
    {
        // Arrange
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            var syrupCappuccino = SyrupCappuccino.MakeSyrupCappuccino(Intensity.NORMAL, 150, SyrupType.CHOCOLATE);

            // Assert
            var result = sw.ToString();
            Assert.IsTrue(result.Contains("Making SyrupCappuccino"));
            Assert.IsTrue(result.Contains("Intensity set to NORMAL"));
            Assert.IsTrue(result.Contains("Adding 150 mls of milk"));
            Assert.IsTrue(result.Contains("Adding CHOCOLATE syrup"));
        }
    }
}