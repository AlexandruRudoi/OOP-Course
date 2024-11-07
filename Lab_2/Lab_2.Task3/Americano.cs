namespace Lab_2.Task3;

internal class Americano : Coffee
{
    private int _mlOfWater;
    private const string CoffeeName = "Americano";

    /// <summary>
    ///     Initializes a new instance of the <see cref="Americano" /> class with the specified intensity and water amount.
    /// </summary>
    /// <param name="intensity">The intensity level of the Americano.</param>
    /// <param name="mlOfWater">The amount of water in milliliters.</param>
    public Americano(Intensity intensity, int mlOfWater) : base(intensity, CoffeeName)
    {
        MlOfWater = mlOfWater;
    }

    /// <summary>
    ///     Gets or sets the amount of water in the Americano.
    /// </summary>
    public int MlOfWater
    {
        get { return _mlOfWater; }
        set { _mlOfWater = value; }
    }

    /// <summary>
    ///     Gets the name of the Americano.
    /// </summary>
    public string Name => CoffeeName;

    /// <summary>
    ///     Prints the details of the Americano.
    /// </summary>
    public override void PrintDetails()
    {
        base.PrintDetails();
        Console.WriteLine($"Americano water: {MlOfWater} ml");
    }

    /// <summary>
    ///     Factory method to make and return an Americano instance.
    /// </summary>
    public static Americano MakeAmericano(Intensity intensity, int mlOfWater)
    {
        var americano = new Americano(intensity, mlOfWater: mlOfWater);
        americano.MakeCoffee();
        Console.WriteLine($"Adding {mlOfWater} mls of water");
        return americano;
    }
}