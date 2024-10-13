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
            Console.WriteLine("Traits: " + string.Join(", ", Traits));
        else
            Console.WriteLine("Traits: None");

        Console.WriteLine();
    }

    /// <summary>
    ///     Classifies the alien species into one of the fictional universes based on its attributes.
    /// </summary>
    public string Classify()
    {
        // Avoid accessing a null reference
        var traits = Traits ?? new List<string>();

        // Scoring system: Each universe has a score based on matches
        var universeScores = new Dictionary<string, double>
        {
            { "Star Wars Universe (Wookie)", 0 },
            { "Star Wars Universe (Ewok)", 0 },
            { "Marvel Universe (Asgardian)", 0 },
            { "Hitchhiker's Universe (Betelgeusian)", 0 },
            { "Hitchhiker's Universe (Vogon)", 0 },
            { "Lord of the Rings (Elf)", 0 },
            { "Lord of the Rings (Dwarf)", 0 }
        };

        // Star Wars Universe (Wookie)
        if (Planet == "Kashyyyk") universeScores["Star Wars Universe (Wookie)"] += 0.4;
        if (traits.Contains("HAIRY") && traits.Contains("TALL"))
            universeScores["Star Wars Universe (Wookie)"] += 0.3;
        if (Age != null && Age >= 0 && Age <= 400) universeScores["Star Wars Universe (Wookie)"] += 0.2;
        if (IsHumanoid == false) universeScores["Star Wars Universe (Wookie)"] += 0.1;

        // Star Wars Universe (Ewok)
        if (Planet == "Endor") universeScores["Star Wars Universe (Ewok)"] += 0.4;
        if (traits.Contains("SHORT") && traits.Contains("HAIRY")) universeScores["Star Wars Universe (Ewok)"] += 0.3;
        if (Age != null && Age >= 0 && Age <= 60) universeScores["Star Wars Universe (Ewok)"] += 0.2;
        if (IsHumanoid == false) universeScores["Star Wars Universe (Ewok)"] += 0.1;

        // Marvel Universe (Asgardian)
        if (Planet == "Asgard") universeScores["Marvel Universe (Asgardian)"] += 0.4;
        if (traits.Contains("BLONDE") && traits.Contains("TALL")) universeScores["Marvel Universe (Asgardian)"] += 0.3;
        if (Age != null && Age >= 0 && Age <= 5000) universeScores["Marvel Universe (Asgardian)"] += 0.2;
        if (IsHumanoid == true) universeScores["Marvel Universe (Asgardian)"] += 0.1;

        // Hitchhiker's Universe (Betelgeusian)
        if (Planet == "Betelgeuse") universeScores["Hitchhiker's Universe (Betelgeusian)"] += 0.4;
        if (traits.Contains("EXTRA_ARMS") && traits.Contains("EXTRA_HEAD"))
            universeScores["Hitchhiker's Universe (Betelgeusian)"] += 0.3;
        if (Age != null && Age >= 0 && Age <= 100) universeScores["Hitchhiker's Universe (Betelgeusian)"] += 0.2;
        if (IsHumanoid == true) universeScores["Hitchhiker's Universe (Betelgeusian)"] += 0.1;

        // Hitchhiker's Universe (Vogon)
        if (Planet == "Vogsphere") universeScores["Hitchhiker's Universe (Vogon)"] += 0.4;
        if (traits.Contains("GREEN") && traits.Contains("BULKY"))
            universeScores["Hitchhiker's Universe (Vogon)"] += 0.3;
        if (Age != null && Age >= 0 && Age <= 200) universeScores["Hitchhiker's Universe (Vogon)"] += 0.2;
        if (IsHumanoid == false) universeScores["Hitchhiker's Universe (Vogon)"] += 0.1;

        // Lord of the Rings (Elf)
        if (Planet == "Earth") universeScores["Lord of the Rings (Elf)"] += 0.4;
        if (traits.Contains("BLONDE") && traits.Contains("POINTY_EARS"))
            universeScores["Lord of the Rings (Elf)"] += 0.3;
        if (Age == null || Age > 200) universeScores["Lord of the Rings (Elf)"] += 0.2;
        if (IsHumanoid == true) universeScores["Lord of the Rings (Elf)"] += 0.1;

        // Lord of the Rings (Dwarf)
        if (Planet == "Earth") universeScores["Lord of the Rings (Dwarf)"] += 0.4;
        if (traits.Contains("SHORT") && traits.Contains("BULKY")) universeScores["Lord of the Rings (Dwarf)"] += 0.3;
        if (Age != null && Age >= 0 && Age <= 200) universeScores["Lord of the Rings (Dwarf)"] += 0.2;
        if (IsHumanoid == true) universeScores["Lord of the Rings (Dwarf)"] += 0.1;

        // Find the universe with the highest score
        var bestMatch = universeScores.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

        // If the best score is too low, return "Unknown Universe"
        if (universeScores[bestMatch] < 0.5) return "Unknown Universe";

        return bestMatch;
    }
}