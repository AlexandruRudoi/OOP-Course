namespace Lab_2.CoffeeShop;

public class SyrupCappuccino : Coffee
{
    private int _mlOfMilk;
    private SyrupType _syrup;
    private const string _coffeeName = "SyrupCappuccino";

    public SyrupCappuccino(Intensity intensity, int mlOfMilk, SyrupType syrup) : base(intensity)
    {
        MlOfMilk = mlOfMilk;
        Syrup = syrup;
    }

    public int MlOfMilk
    {
        get { return _mlOfMilk; }
        set { _mlOfMilk = value; }
    }

    public SyrupType Syrup
    {
        get { return _syrup; }
        set { _syrup = value; }
    }

    public string CoffeeName => _coffeeName;
}