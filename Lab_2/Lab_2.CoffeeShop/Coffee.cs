namespace Lab_2.CoffeeShop;

public class Coffee
{
    private Intensity _coffeeIntensity;
    private const string _name = "Coffee";

    public Coffee(Intensity intensity)
    {
        CoffeeIntensity = intensity;
    }

    public Intensity CoffeeIntensity
    {
        get { return _coffeeIntensity; }
        set { _coffeeIntensity = value; }
    }

    public string Name => _name;
}