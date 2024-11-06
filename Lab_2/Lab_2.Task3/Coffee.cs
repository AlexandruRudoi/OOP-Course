namespace Lab_2.Task3;

public class Coffee
{
    private Intensity _coffeeIntensity;
    private const string _name = "Coffee";

    /// <summary>
    ///     Initializes a new instance of the <see cref="Coffee" /> class with the specified intensity.
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

    /// <summary>
    ///     Prints the details of making a coffee. This can be overridden in derived classes.
    /// </summary>
    /// <param name="coffeeType">The specific type of coffee being made, such as "Cappuccino" or "Americano".</param>
    /// <param name="mlOfMilk">The amount of milk in milliliters, if applicable. Pass null if milk is not required.</param>
    /// <param name="mlOfWater">The amount of water in milliliters, if applicable. Pass null if water is not required.</param>
    protected void MakeCoffee(string? coffeeType = null, int? mlOfMilk = null, int? mlOfWater = null)
    {
        if (coffeeType != null)
            Console.WriteLine($"Making {coffeeType}");
        else
            Console.WriteLine($"Making {Name}");

        Console.WriteLine($"Intensity set to {CoffeeIntensity}");

        if (mlOfMilk.HasValue)
            Console.WriteLine($"Adding {mlOfMilk} mls of milk");
        else if (mlOfWater.HasValue)
            Console.WriteLine($"Adding {mlOfWater} mls of water");
    }
}