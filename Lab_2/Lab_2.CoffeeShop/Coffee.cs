namespace Lab_2.CoffeeShop;

public class Coffee
{
    private Intensity _coffeeIntensity;
    private const string _name = "Coffee";

    /// <summary>
    ///     Initializes a new instance of the <see cref="Coffee"/> class with the specified intensity.
    /// </summary>
    /// <param name="intensity">The intensity level of the coffee.</param>
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
    public string Name => _name;

    /// <summary>
    ///     Prints the details of the coffee.
    /// </summary>
    public virtual void PrintDetails()
    {
        Console.WriteLine($"Coffee intensity: {CoffeeIntensity}");
    }
}