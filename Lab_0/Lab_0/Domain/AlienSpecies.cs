namespace Lab_0.Domain;

public class AlienSpecies
{
    private int _id;
    private bool? _isHumanoid;
    private string _planet;
    private int? _age;
    private List<string> _traits;

    /// <summary>
    ///     Gets or sets the unique ID of the alien species.
    /// </summary>
    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    /// <summary>
    ///     Gets or sets a value indicating whether the alien species is humanoid.
    /// </summary>
    public bool? IsHumanoid
    {
        get { return _isHumanoid; }
        set { _isHumanoid = value; }
    }

    /// <summary>
    ///     Gets or sets the planet where the alien species is from.
    /// </summary>
    public string Planet
    {
        get { return _planet; }
        set { _planet = value; }
    }

    /// <summary>
    ///     Gets or sets the age of the alien species.
    /// </summary>
    public int? Age
    {
        get { return _age; }
        set { _age = value; }
    }

    /// <summary>
    ///     Gets or sets the list of traits associated with the alien species.
    /// </summary>
    public List<string> Traits
    {
        get { return _traits; }
        set { _traits = value; }
    }

    /// <summary>
    ///     Prints the details of the alien species including ID, planet, age, humanoid status, and traits.
    /// </summary>
    public void PrintSpecies()
    {
        Console.WriteLine($"ID: {Id}, Planet: {Planet}, Age: {Age}, Humanoid: {IsHumanoid}");

        if (Traits != null && Traits.Count > 0)
        {
            Console.WriteLine("Traits: " + string.Join(", ", Traits));
        }
        else
        {
            Console.WriteLine("Traits: None");
        }

        Console.WriteLine();
    }
}