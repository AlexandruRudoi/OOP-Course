using Lab_2.Task4;

namespace Lab_2;

internal class Program
{
    private static void Main(string[] args)
    {
        var barista = new Barista();
        var orders =
            new List<(string CoffeeType, Intensity Intensity, int? MlOfMilk, int? MgOfPumpkinSpice, SyrupType? Syrup
                )>();
        bool addingMoreCoffees = true;

        Console.WriteLine("Welcome to the Coffee Shop!\n");

        while (addingMoreCoffees)
        {
            Console.WriteLine("What would you like to order?");
            Console.WriteLine("1. Cappuccino");
            Console.WriteLine("2. Pumpkin Spice Latte");
            Console.WriteLine("3. Americano");
            Console.WriteLine("4. Syrup Cappuccino");
            Console.WriteLine("5. Finish and Place Order\n");

            Console.Write("Please select an option (1-5): ");
            var choice = Console.ReadLine();

            string coffeeType = string.Empty;
            Intensity intensity = Intensity.NORMAL;
            int? mlOfMilk = null;
            int? mgOfPumpkinSpice = null;
            SyrupType? syrupType = null;

            switch (choice)
            {
                case "1":
                    coffeeType = "Cappuccino";
                    mlOfMilk = GetMilkAmount();
                    intensity = GetIntensity();
                    break;

                case "2":
                    coffeeType = "PumpkinSpiceLatte";
                    mlOfMilk = GetMilkAmount();
                    mgOfPumpkinSpice = GetPumpkinSpiceAmount();
                    intensity = GetIntensity();
                    break;

                case "3":
                    coffeeType = "Americano";
                    intensity = GetIntensity();
                    break;

                case "4":
                    coffeeType = "SyrupCappuccino";
                    mlOfMilk = GetMilkAmount();
                    syrupType = GetSyrupType();
                    intensity = GetIntensity();
                    break;

                case "5":
                    addingMoreCoffees = false;
                    continue;

                default:
                    Console.WriteLine("Invalid option, please try again.\n");
                    continue;
            }

            if (!string.IsNullOrEmpty(coffeeType))
            {
                orders.Add((coffeeType, intensity, mlOfMilk, mgOfPumpkinSpice, syrupType));
                Console.WriteLine($"{coffeeType} added to your order!\n");
            }
        }

        Console.WriteLine("\nPreparing your order...\n");
        barista.TakeOrder(orders);
    }

    private static Intensity GetIntensity()
    {
        Console.WriteLine("Select Intensity:");
        Console.WriteLine("1. Light");
        Console.WriteLine("2. Normal");
        Console.WriteLine("3. Strong");
        Console.Write("Please select an option (1-3): ");
        var choice = Console.ReadLine();

        return choice switch
        {
            "1" => Intensity.LIGHT,
            "2" => Intensity.NORMAL,
            "3" => Intensity.STRONG,
            _ => Intensity.NORMAL
        };
    }

    private static int GetMilkAmount()
    {
        Console.Write("Enter amount of milk in ml: ");
        if (int.TryParse(Console.ReadLine(), out int mlOfMilk))
        {
            return mlOfMilk;
        }

        Console.WriteLine("Invalid input. Setting milk to 50 ml by default.");
        return 50; // Default value
    }

    private static int GetPumpkinSpiceAmount()
    {
        Console.Write("Enter amount of pumpkin spice in mg: ");
        if (int.TryParse(Console.ReadLine(), out int mgOfPumpkinSpice))
        {
            return mgOfPumpkinSpice;
        }

        Console.WriteLine("Invalid input. Setting pumpkin spice to 10 mg by default.");
        return 10; // Default value
    }

    private static SyrupType GetSyrupType()
    {
        Console.WriteLine("Select Syrup Type:");
        Console.WriteLine("1. Macadamia");
        Console.WriteLine("2. Vanilla");
        Console.WriteLine("3. Coconut");
        Console.WriteLine("4. Caramel");
        Console.WriteLine("5. Chocolate");
        Console.WriteLine("6. Popcorn");
        Console.Write("Please select an option (1-6): ");
        var choice = Console.ReadLine();

        return choice switch
        {
            "1" => SyrupType.MACADAMIA,
            "2" => SyrupType.VANILLA,
            "3" => SyrupType.COCONUT,
            "4" => SyrupType.CARAMEL,
            "5" => SyrupType.CHOCOLATE,
            "6" => SyrupType.POPCORN,
            _ => SyrupType.CARAMEL // Default value
        };
    }
}