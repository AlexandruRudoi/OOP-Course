namespace Lab_2.Task4;

internal class SyrupCappuccino : Cappuccino
{
    private int _mlOfMilk;
    private SyrupType _syrup;
    private const string CoffeeName = "SyrupCappuccino";

    /// <summary>
    ///     Initializes a new instance of the <see cref="SyrupCappuccino" /> class with the specified intensity, milk, and
    ///     syrup type.
    /// </summary>
    /// <param name="intensity">The intensity level of the syrup cappuccino.</param>
    /// <param name="mlOfMilk">The amount of milk in milliliters.</param>
    /// <param name="syrup">The type of syrup added to the cappuccino.</param>
    public SyrupCappuccino(Intensity intensity, int mlOfMilk, SyrupType syrup) : base(intensity, mlOfMilk)
    {
        MlOfMilk = mlOfMilk;
        Syrup = syrup;
    }

    /// <summary>
    ///     Gets or sets the amount of milk in the cappuccino.
    /// </summary>
    public override int MlOfMilk
    {
        get { return _mlOfMilk; }
        set { _mlOfMilk = value; }
    }

    /// <summary>
    ///     Gets or sets the type of syrup in the cappuccino.
    /// </summary>
    public SyrupType Syrup
    {
        get { return _syrup; }
        set { _syrup = value; }
    }

    /// <summary>
    ///     Gets the name of the coffee.
    /// </summary>
    public override string Name => CoffeeName;

    /// <summary>
    ///     Prints the details of the Syrup Cappuccino.
    /// </summary>
    public override void PrintDetails()
    {
        base.PrintDetails();
        Console.WriteLine($"Syrup Cappuccino milk: {MlOfMilk} mg");
        Console.WriteLine($"Syrup flavor: {Syrup}");
    }

    /// <summary>
    ///     Prints the details of making a syrupCappuccino.
    /// </summary>
    protected override void MakeReceipe()
    {
        base.MakeReceipe();
        Console.WriteLine($"Adding {Syrup} syrup");
    }

    /// <summary>
    ///     Factory method to make and return a Syrup Cappuccino instance.
    /// </summary>
    public SyrupCappuccino MakeSyrupCappuccino()
    {
        MakeReceipe();
        return this;
    }
}