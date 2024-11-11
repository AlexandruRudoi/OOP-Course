namespace Lab_2.Task4;

internal class PumpkinSpiceLatte : Cappuccino
{
    private int _mlOfMilk;
    private int _mgOfPumpkinSpice;
    private const string CoffeeName = "PumpkinSpiceLatte";

    /// <summary>
    ///     Initializes a new instance of the <see cref="PumpkinSpiceLatte" /> class with the specified intensity, milk, and
    ///     pumpkin spice amounts.
    /// </summary>
    /// <param name="intensity">The intensity level of the latte.</param>
    /// <param name="mlOfMilk">The amount of milk in milliliters.</param>
    /// <param name="mgOfPumpkinSpice">The amount of pumpkin spice in milligrams.</param>
    public PumpkinSpiceLatte(Intensity intensity, int mlOfMilk, int mgOfPumpkinSpice) : base(intensity, mlOfMilk)
    {
        MlOfMilk = mlOfMilk;
        MgOfPumpkinSpice = mgOfPumpkinSpice;
    }

    /// <summary>
    ///     Gets or sets the amount of milk in the latte.
    /// </summary>
    public override int MlOfMilk
    {
        get { return _mlOfMilk; }
        set { _mlOfMilk = value; }
    }

    /// <summary>
    ///     Gets the name of the coffee.
    /// </summary>
    public override string Name => CoffeeName;

    /// <summary>
    ///     Gets or sets the amount of pumpkin spice in the latte.
    /// </summary>
    public int MgOfPumpkinSpice
    {
        get { return _mgOfPumpkinSpice; }
        set { _mgOfPumpkinSpice = value; }
    }

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
    ///     Prints the details of making a pumpkinSpiceLatte.
    /// </summary>
    protected override void MakeReceipe()
    {
        base.MakeReceipe();
        Console.WriteLine($"Adding {MgOfPumpkinSpice} mls of pumpkin spice");
    }

    /// <summary>
    ///     Factory method to make and return a Pumpkin Spice Latte instance.
    /// </summary>
    public PumpkinSpiceLatte MakePumpkinSpiceLatte()
    {
        MakeReceipe();
        return this;
    }
}