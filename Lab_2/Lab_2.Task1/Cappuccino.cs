namespace Lab_2.Task1;

public class Cappuccino : Coffee
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
}