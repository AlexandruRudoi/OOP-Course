using Lab_2.Task4;

namespace Lab_2;

internal class Program
{
    /// <summary>
    ///     Main method for the Coffee Shop application.
    ///     This method provides an interactive menu to allow users to place coffee orders and then prepares each coffee.
    /// </summary>
    private static void Main(string[] args)
    {
        var barista = new Barista();
        var orders =
            new List<(string CoffeeType, Intensity Intensity, int? MlOfMilk, int? MgOfPumpkinSpice, SyrupType? Syrup
                )>();
        var addingMoreCoffees = true;

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

            var coffeeType = string.Empty;
            var intensity = Intensity.NORMAL;
            int? mlOfLiquid = null;
            int? mgOfPumpkinSpice = null;
            SyrupType? syrupType = null;

            switch (choice)
            {
                case "1":
                    coffeeType = "Cappuccino";
                    mlOfLiquid = GetLiquidAmount("milk");
                    intensity = GetIntensity();
                    break;

                case "2":
                    coffeeType = "PumpkinSpiceLatte";
                    mlOfLiquid = GetLiquidAmount("milk");
                    mgOfPumpkinSpice = GetPumpkinSpiceAmount();
                    intensity = GetIntensity();
                    break;

                case "3":
                    coffeeType = "Americano";
                    mlOfLiquid = GetLiquidAmount("water");
                    intensity = GetIntensity();
                    break;

                case "4":
                    coffeeType = "SyrupCappuccino";
                    mlOfLiquid = GetLiquidAmount("milk");
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
                orders.Add((coffeeType, intensity, mlOfLiquid, mgOfPumpkinSpice, syrupType));
                Console.WriteLine($"{coffeeType} added to your order!\n");
            }
        }

        Console.WriteLine("\nPreparing your order...\n");
        barista.TakeOrder(orders);
    }

    /// <summary>
    ///     Prompts the user to select an intensity level for the coffee.
    /// </summary>
    /// <returns>The selected <see cref="Intensity" /> of the coffee.</returns>
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

    /// <summary>
    ///     Prompts the user to enter the amount of liquid in milliliters.
    /// </summary>
    /// <returns>The amount of milk in milliliters as an integer.</returns>
    private static int GetLiquidAmount(string type)
    {
        Console.Write($"Enter amount of {type} in ml: ");
        if (int.TryParse(Console.ReadLine(), out var mlOfLiquid)) return mlOfLiquid;

        Console.WriteLine($"Invalid input. Setting {type} to 50 ml by default.");
        return 50; // Default value
    }

    /// <summary>
    ///     Prompts the user to enter the amount of pumpkin spice in milligrams.
    /// </summary>
    /// <returns>The amount of pumpkin spice in milligrams as an integer.</returns>
    private static int GetPumpkinSpiceAmount()
    {
        Console.Write("Enter amount of pumpkin spice in mg: ");
        if (int.TryParse(Console.ReadLine(), out var mgOfPumpkinSpice)) return mgOfPumpkinSpice;

        Console.WriteLine("Invalid input. Setting pumpkin spice to 10 mg by default.");
        return 10; // Default value
    }

    /// <summary>
    ///     Prompts the user to select a syrup type for the coffee.
    /// </summary>
    /// <returns>The selected <see cref="SyrupType" /> for the coffee.</returns>
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