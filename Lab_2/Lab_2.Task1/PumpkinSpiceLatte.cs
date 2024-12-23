﻿namespace Lab_2.Task1;

public class PumpkinSpiceLatte : Coffee
{
    private int _mlOfMilk;
    private int _mgOfPumpkinSpice;
    private const string _coffeeName = "PumpkinSpiceLatte";

    /// <summary>
    ///     Initializes a new instance of the <see cref="PumpkinSpiceLatte" /> class with the specified intensity, milk, and
    ///     pumpkin spice amounts.
    /// </summary>
    /// <param name="intensity">The intensity level of the latte.</param>
    /// <param name="mlOfMilk">The amount of milk in milliliters.</param>
    /// <param name="mgOfPumpkinSpice">The amount of pumpkin spice in milligrams.</param>
    public PumpkinSpiceLatte(Intensity intensity, int mlOfMilk, int mgOfPumpkinSpice) : base(intensity)
    {
        MlOfMilk = mlOfMilk;
        MgOfPumpkinSpice = mgOfPumpkinSpice;
    }

    /// <summary>
    ///     Gets or sets the amount of milk in the latte.
    /// </summary>
    public int MlOfMilk
    {
        get { return _mlOfMilk; }
        set { _mlOfMilk = value; }
    }

    /// <summary>
    ///     Gets or sets the amount of pumpkin spice in the latte.
    /// </summary>
    public int MgOfPumpkinSpice
    {
        get { return _mgOfPumpkinSpice; }
        set { _mgOfPumpkinSpice = value; }
    }
    
    /// <summary>
    ///     Gets the name of the Pumpkin Spice Latte.
    /// </summary>
    public string CoffeeName => _coffeeName;
}