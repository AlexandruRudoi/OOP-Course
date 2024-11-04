namespace Lab_2.CoffeeShop;

public class PumpkinSpiceLatte : Coffee
{
    private int _mlOfMilk;
    private int _mgOfPumpkinSpice;
    private const string _coffeeName = "PumpkinSpiceLatte";

    public PumpkinSpiceLatte(Intensity intensity, int mlOfMilk, int mgOfPumpkinSpice) : base(intensity)
    {
        MlOfMilk = mlOfMilk;
        MgOfPumpkinSpice = mgOfPumpkinSpice;
    }

    public int MlOfMilk
    {
        get { return _mlOfMilk; }
        set { _mlOfMilk = value; }
    }

    public int MgOfPumpkinSpice
    {
        get { return _mgOfPumpkinSpice; }
        set { _mgOfPumpkinSpice = value; }
    }
    
    public string CoffeeName => _coffeeName;
}