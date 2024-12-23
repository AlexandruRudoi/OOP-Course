﻿namespace Lab_2.Task1;

public class SyrupCappuccino : Coffee
{
    private int _mlOfMilk;
    private SyrupType _syrup;
    private const string _coffeeName = "SyrupCappuccino";

    /// <summary>
    ///     Initializes a new instance of the <see cref="SyrupCappuccino" /> class with the specified intensity, milk, and
    ///     syrup type.
    /// </summary>
    /// <param name="intensity">The intensity level of the syrup cappuccino.</param>
    /// <param name="mlOfMilk">The amount of milk in milliliters.</param>
    /// <param name="syrup">The type of syrup added to the cappuccino.</param>
    public SyrupCappuccino(Intensity intensity, int mlOfMilk, SyrupType syrup) : base(intensity)
    {
        MlOfMilk = mlOfMilk;
        Syrup = syrup;
    }

    /// <summary>
    ///     Gets or sets the amount of milk in the cappuccino.
    /// </summary>
    public int MlOfMilk
    {
        get { return _mlOfMilk; }
        set { _mlOfMilk = value; }
    }

    /// <summary>
    ///     Gets or sets the type of syrup in the cappuccino.
    /// </summary>
    public SyrupType Syrup
    {
        get { return _syrup; }
        set { _syrup = value; }
    }

    /// <summary>
    ///     Gets the name of the syrup cappuccino.
    /// </summary>
    public string CoffeeName => _coffeeName;
}