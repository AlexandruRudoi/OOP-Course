namespace Lab_2.Task3;

internal class Cappuccino : Coffee
{
    private int _mlOfMilk;
    private const string CoffeeName = "Cappuccino";

    /// <summary>
    ///     Initializes a new instance of the <see cref="Cappuccino" /> class with the specified intensity and milk amount.
    /// </summary>
    /// <param name="intensity">The intensity level of the cappuccino.</param>
    /// <param name="mlOfMilk">The amount of milk in milliliters.</param>
    public Cappuccino(Intensity intensity, int mlOfMilk) : base(intensity, CoffeeName)
    {
        MlOfMilk = mlOfMilk;
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
    ///     Prints the details of the cappuccino.
    /// </summary>
    public override void PrintDetails()
    {
        base.PrintDetails();
        Console.WriteLine($"Cappuccino milk: {MlOfMilk} mg");
    }

    /// <summary>
    ///     Factory method to make and return a Cappuccino instance.
    /// </summary>
    public static Cappuccino MakeCappuccino(Intensity intensity, int mlOfMilk)
    {
        var cappuccino = new Cappuccino(intensity, mlOfMilk);
        cappuccino.MakeCoffee();
        Console.WriteLine($"Adding {mlOfMilk} mls of milk");
        return cappuccino;
    }
}