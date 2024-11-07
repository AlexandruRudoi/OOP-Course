namespace Lab_2.Task3;

internal class SyrupCappuccino : Coffee
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
    public SyrupCappuccino(Intensity intensity, int mlOfMilk, SyrupType syrup) : base(intensity, CoffeeName)
    {
        MlOfMilk = mlOfMilk;
        Syrup = syrup;
    }

    /// <summary>
    ///     Gets or sets the amount of milk in the cappuccino.
    /// </summary>
    public int MlOfMilk
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
    ///     Prints the details of the Syrup Cappuccino.
    /// </summary>
    public override void PrintDetails()
    {
        base.PrintDetails();
        Console.WriteLine($"Syrup Cappuccino milk: {MlOfMilk} mg");
        Console.WriteLine($"Syrup flavor: {Syrup}");
    }

    /// <summary>
    ///     Factory method to make and return a Syrup Cappuccino instance.
    /// </summary>
    public static SyrupCappuccino MakeSyrupCappuccino(Intensity intensity, int mlOfMilk, SyrupType syrup)
    {
        var syrupCappuccino = new SyrupCappuccino(intensity, mlOfMilk, syrup);
        syrupCappuccino.MakeCoffee();
        Console.WriteLine($"Adding {mlOfMilk} mls of milk");
        Console.WriteLine($"Adding {syrup} syrup");
        return syrupCappuccino;
    }
}