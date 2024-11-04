using Lab_2.CoffeeShop;

namespace Lab_2;

internal class Program
{
    private static void Main(string[] args)
    {
        Coffee basicCoffee = new Coffee(Intensity.NORMAL);
        Cappuccino cappuccino = new Cappuccino(Intensity.STRONG, 150);
        PumpkinSpiceLatte pumpkinLatte = new PumpkinSpiceLatte(Intensity.LIGHT, 200, 10);
        Americano americano = new Americano(Intensity.STRONG, 250);
        SyrupCappuccino syrupCappuccino = new SyrupCappuccino(Intensity.NORMAL, 150, SyrupType.CARAMEL);

        // Display some information about each coffee
        Console.WriteLine(
            $"{cappuccino.CoffeeName} with milk: {cappuccino.MlOfMilk}ml, Intensity: {cappuccino.CoffeeIntensity}");
    }
}