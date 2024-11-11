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
            var cappuccino = new Cappuccino(Intensity.NORMAL, 50);
            cappuccino.MakeCappuccino();

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
            var pumpkinLatte = new PumpkinSpiceLatte(Intensity.STRONG, 100, 10);
            pumpkinLatte.MakePumpkinSpiceLatte();

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
            var americano = new Americano(Intensity.LIGHT, 200);
            americano.MakeAmericano();

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
            var syrupCappuccino = new SyrupCappuccino(Intensity.NORMAL, 150, SyrupType.CHOCOLATE);
            syrupCappuccino.MakeSyrupCappuccino();

            // Assert
            var result = sw.ToString();
            Assert.IsTrue(result.Contains("Making SyrupCappuccino"));
            Assert.IsTrue(result.Contains("Intensity set to NORMAL"));
            Assert.IsTrue(result.Contains("Adding 150 mls of milk"));
            Assert.IsTrue(result.Contains("Adding CHOCOLATE syrup"));
        }
    }
}