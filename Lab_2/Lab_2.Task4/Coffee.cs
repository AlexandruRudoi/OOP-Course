namespace Lab_2.Task4;

internal class Coffee
{
    private Intensity _coffeeIntensity;
    private const string _name = "Coffee";

    /// <summary>
    ///     Initializes a new instance of the <see cref="Coffee" /> class with the specified intensity.
    /// </summary>
    /// <param name="intensity">The intensity level of the coffee.</param>
    /// <param name="name">The name of the coffee.</param>
    public Coffee(Intensity intensity)
    {
        CoffeeIntensity = intensity;
    }

    /// <summary>
    ///     Gets or sets the intensity of the coffee.
    /// </summary>
    public Intensity CoffeeIntensity
    {
        get { return _coffeeIntensity; }
        set { _coffeeIntensity = value; }
    }

    /// <summary>
    ///     Gets the name of the coffee.
    /// </summary>
    public virtual string Name => _name;

    /// <summary>
    ///     Prints the details of the coffee.
    /// </summary>
    public virtual void PrintDetails()
    {
        Console.WriteLine($"Coffee intensity: {CoffeeIntensity}");
    }

    /// <summary>
    ///     Prints the details of making a coffee. This can be overridden in derived classes.
    /// </summary>
    protected virtual void MakeReceipe()
    {
        Console.WriteLine($"Making {Name}");
        Console.WriteLine($"Intensity set to {CoffeeIntensity}");
    }

    /// <summary>
    ///     Prints the details of making a coffee.
    /// </summary>
    public Coffee MakeCoffee()
    {
        MakeReceipe();
        return this;
    }
}