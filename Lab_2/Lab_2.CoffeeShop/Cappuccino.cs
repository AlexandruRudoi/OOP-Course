namespace Lab_2.CoffeeShop;

public class Cappuccino : Coffee
{
    private int _mlOfMilk;
    private const string _coffeeName = "Cappuccino";

    public Cappuccino(Intensity intensity, int mlOfMilk) : base(intensity)
    {
        MlOfMilk = mlOfMilk;
    }
    
    public int MlOfMilk
    {
        get { return _mlOfMilk; }
        set { _mlOfMilk = value; }
    }
    
    public string CoffeeName => _coffeeName;
}