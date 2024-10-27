namespace Lab_1.Domain;

public class Assistant
{
    private string _assistantName;
    private List<Display> _assignedDisplays;

    /// <summary>
    /// Initializes a new instance of the Assistant class with the specified name.
    /// </summary>
    /// <param name="assistantName">The name of the assistant.</param>
    public Assistant(string assistantName)
    {
        this._assistantName = assistantName;
        this._assignedDisplays = new List<Display>();
    }

    /// <summary>
    /// Adds a Display object to the assignedDisplays list.
    /// </summary>
    /// <param name="d">The Display object to be assigned to the assistant.</param>
    public void AssignDisplay(Display d)
    {
        _assignedDisplays.Add(d);
        Console.WriteLine($"{d.Model} has been assigned to {_assistantName}.");
    }

    /// <summary>
    /// Compares each Display object in the assignedDisplays list sequentially.
    /// </summary>
    public void Assist()
    {
        Console.WriteLine($"Assistant {_assistantName} is helping with display comparison:");

        if (_assignedDisplays.Count < 2)
        {
            Console.WriteLine("Not enough displays to compare.");
            return;
        }

        for (int i = 0; i < _assignedDisplays.Count - 1; i++)
        {
            Display current = _assignedDisplays[i];
            Display next = _assignedDisplays[i + 1];

            current.CompareWithMonitor(next);
        }
    }

    /// <summary>
    /// Removes a specified Display object from the assignedDisplays list and returns it.
    /// </summary>
    /// <param name="d">The Display object to be bought.</param>
    /// <returns>The Display object that was removed from the list, or null if not found.</returns>
    public Display BuyDisplay(Display d)
    {
        if (_assignedDisplays.Remove(d))
        {
            Console.WriteLine($"{d.Model} has been bought and removed from {_assistantName}'s assigned displays.");
            return d;
        }
        else
        {
            Console.WriteLine($"{d.Model} could not be found in {_assistantName}'s assigned displays.");
            return null;
        }
    }
}