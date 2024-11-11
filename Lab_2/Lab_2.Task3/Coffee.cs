namespace Lab_2.Task3;

public class Coffee
{
    private Intensity _coffeeIntensity;
    private readonly string _name = "Coffee";

    /// <summary>
    ///     Initializes a new instance of the <see cref="Coffee" /> class with the specified intensity.
    /// </summary>
    /// <param name="intensity">The intensity level of the coffee.</param>
    /// <param name="name">The name of the coffee.</param>
    public Coffee(Intensity intensity, string name)
    {
        CoffeeIntensity = intensity;
        this._name = name;
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
    public string Name => _name;

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
    protected void MakeCoffee()
    {
        Console.WriteLine($"Making {Name}");
        Console.WriteLine($"Intensity set to {CoffeeIntensity}");
    }
}