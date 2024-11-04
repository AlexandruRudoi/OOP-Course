namespace Lab_2.Task3;

public class PumpkinSpiceLatte : Coffee
{
    private int _mlOfMilk;
    private int _mgOfPumpkinSpice;
    private const string _coffeeName = "PumpkinSpiceLatte";

    /// <summary>
    ///     Initializes a new instance of the <see cref="PumpkinSpiceLatte"/> class with the specified intensity, milk, and pumpkin spice amounts.
    /// </summary>
    /// <param name="intensity">The intensity level of the latte.</param>
    /// <param name="mlOfMilk">The amount of milk in milliliters.</param>
    /// <param name="mgOfPumpkinSpice">The amount of pumpkin spice in milligrams.</param>
    public PumpkinSpiceLatte(Intensity intensity, int mlOfMilk, int mgOfPumpkinSpice) : base(intensity)
    {
        MlOfMilk = mlOfMilk;
        MgOfPumpkinSpice = mgOfPumpkinSpice;
    }

    /// <summary>
    ///     Gets or sets the amount of milk in the latte.
    /// </summary>
    public int MlOfMilk
    {
        get { return _mlOfMilk; }
        set { _mlOfMilk = value; }
    }

    /// <summary>
    ///     Gets or sets the amount of pumpkin spice in the latte.
    /// </summary>
    public int MgOfPumpkinSpice
    {
        get { return _mgOfPumpkinSpice; }
        set { _mgOfPumpkinSpice = value; }
    }

    /// <summary>
    ///     Gets the name of the Pumpkin Spice Latte.
    /// </summary>
    public string CoffeeName => _coffeeName;

    /// <summary>
    ///     Prints the details of the Pumpkin Spice Latte.
    /// </summary>
    public override void PrintDetails()
    {
        base.PrintDetails();
        Console.WriteLine($"Pumpkin Spice Latte milk: {MlOfMilk} mg");
        Console.WriteLine($"Pumpkin spice: {MgOfPumpkinSpice} mg");
    }

    /// <summary>
    ///     Method to make Pumpkin Spice Latte, providing specific steps.
    /// </summary>
    public sealed override void MakeCoffee()
    {
        Console.WriteLine($"Making {CoffeeName}");
        Console.WriteLine($"Intensity set to {CoffeeIntensity}");
        Console.WriteLine($"Adding {MlOfMilk} mls of milk");
        Console.WriteLine($"Adding {MgOfPumpkinSpice} mls of pumpkin spice");
    }

    /// <summary>
    ///     Factory method to make and return a Pumpkin Spice Latte instance.
    /// </summary>
    public static PumpkinSpiceLatte MakePumpkinSpiceLatte(Intensity intensity, int mlOfMilk, int mgOfPumpkinSpice)
    {
        var pumpkinLatte = new PumpkinSpiceLatte(intensity, mlOfMilk, mgOfPumpkinSpice);
        pumpkinLatte.MakeCoffee();
        return pumpkinLatte;
    }
}