namespace Lab_0.Domain;

public class AlienSpecies
{
    private int _id;
    private bool? _isHumanoid;
    private string _planet;
    private int? _age;
    private List<string> _traits;

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public bool? IsHumanoid
    {
        get { return _isHumanoid; }
        set { _isHumanoid = value; }
    }

    public string Planet
    {
        get { return _planet; }
        set { _planet = value; }
    }

    public int? Age
    {
        get { return _age; }
        set { _age = value; }
    }

    public List<string> Traits
    {
        get { return _traits; }
        set { _traits = value; }
    }

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