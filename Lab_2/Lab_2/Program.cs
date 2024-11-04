using Lab_2.Task2;

namespace Lab_2;

internal class Program
{
    private static void Main(string[] args)
    {
        Coffee basicCoffee = new Coffee(Intensity.NORMAL);
        Cappuccino cappuccino = new Cappuccino(Intensity.STRONG, 50);
        PumpkinSpiceLatte pumpkinLatte = new PumpkinSpiceLatte(Intensity.LIGHT, 200, 10);
        Americano americano = new Americano(Intensity.STRONG, 250);
        SyrupCappuccino syrupCappuccino = new SyrupCappuccino(Intensity.NORMAL, 150, SyrupType.CARAMEL);

        // Print details of each coffee
        cappuccino.PrintDetails();
        Console.WriteLine();

        pumpkinLatte.PrintDetails();
        Console.WriteLine();

        americano.PrintDetails();
        Console.WriteLine();

        syrupCappuccino.PrintDetails();
    }
}