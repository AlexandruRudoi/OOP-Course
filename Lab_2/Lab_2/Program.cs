using Lab_2.Task3;

namespace Lab_2;

internal class Program
{
    private static void Main(string[] args)
    {
        // Make each type of coffee using factory methods
        Cappuccino.MakeCappuccino(Intensity.NORMAL, 50);
        Console.WriteLine();

        PumpkinSpiceLatte.MakePumpkinSpiceLatte(Intensity.NORMAL, 100, 50);
        Console.WriteLine();

        Americano.MakeAmericano(Intensity.STRONG, 250);
        Console.WriteLine();

        SyrupCappuccino.MakeSyrupCappuccino(Intensity.NORMAL, 150, SyrupType.CARAMEL);
    }
}