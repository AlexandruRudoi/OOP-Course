namespace Lab_2.Task4;

internal class Cappuccino : Coffee
{
    private int _mlOfMilk;
    private const string CoffeeName = "Cappuccino";

    /// <summary>
    ///     Initializes a new instance of the <see cref="Cappuccino" /> class with the specified intensity and milk amount.
    /// </summary>
    /// <param name="intensity">The intensity level of the cappuccino.</param>
    /// <param name="mlOfMilk">The amount of milk in milliliters.</param>
    public Cappuccino(Intensity intensity, int mlOfMilk) : base(intensity)
    {
        MlOfMilk = mlOfMilk;
    }

    /// <summary>
    ///     Gets or sets the amount of milk in the cappuccino.
    /// </summary>
    public virtual int MlOfMilk
    {
        get { return _mlOfMilk; }
        set { _mlOfMilk = value; }
    }

    /// <summary>
    ///     Gets the name of the coffee.
    /// </summary>
    public override string Name => CoffeeName;

    /// <summary>
    ///     Prints the details of the cappuccino.
    /// </summary>
    public override void PrintDetails()
    {
        base.PrintDetails();
        Console.WriteLine($"Cappuccino milk: {MlOfMilk} mg");
    }

    /// <summary>
    ///     Prints the details of making a cappuccino.
    /// </summary>
    protected override void MakeReceipe()
    {
        base.MakeReceipe();
        Console.WriteLine($"Adding {MlOfMilk} mls of milk");
    }

    /// <summary>
    ///     Factory method to make and return a Cappuccino instance.
    /// </summary>
    public Cappuccino MakeCappuccino()
    {
        MakeReceipe();
        return this;
    }
}