namespace Lab_2.Task4;

internal class Cappuccino : Coffee
{
    private int _mlOfMilk;
    private const string _coffeeName = "Cappuccino";
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="Cappuccino"/> class with the specified intensity and milk amount.
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
    public int MlOfMilk
    {
        get { return _mlOfMilk; }
        set { _mlOfMilk = value; }
    }

    /// <summary>
    ///     Gets the name of the cappuccino.
    /// </summary>
    public string CoffeeName => _coffeeName;

    /// <summary>
    ///     Prints the details of the cappuccino.
    /// </summary>
    public override void PrintDetails()
    {
        base.PrintDetails();
        Console.WriteLine($"Cappuccino milk: {MlOfMilk} mg");
    }

    /// <summary>
    ///     Method to make Cappuccino, providing specific steps.
    /// </summary>
    public sealed override void MakeCoffee()
    {
        Console.WriteLine($"Making {CoffeeName}");
        Console.WriteLine($"Intensity set to {CoffeeIntensity}");
        Console.WriteLine($"Adding {MlOfMilk} mls of milk");
    }

    /// <summary>
    ///     Factory method to make and return a Cappuccino instance.
    /// </summary>
    public static Cappuccino MakeCappuccino(Intensity intensity, int mlOfMilk)
    {
        var cappuccino = new Cappuccino(intensity, mlOfMilk);
        cappuccino.MakeCoffee();
        return cappuccino;
    }
}