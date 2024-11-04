namespace Lab_2.CoffeeShop;

public class Americano : Coffee
{
    private int _mlOfWater;
    private const string _coffeeName = "Americano";

    public Americano(Intensity intensity, int mlOfWater) : base(intensity)
    {
        MlOfWater = mlOfWater;
    }

    public int MlOfWater
    {
        get { return _mlOfWater; }
        set { _mlOfWater = value; }
    }

    public string CoffeeName => _coffeeName;
}