namespace Lab_3.Domain;

public class Car
{
    public string Id { get; set; }
    public string Type { get; set; } // ELECTRIC or GAS
    public string Passengers { get; set; } // PEOPLE or ROBOTS
    public bool IsDining { get; set; }
    public int Consumption { get; set; }

    public Car(string id, string type, string passengers, bool isDining, int consumption)
    {
        Id = id;
        Type = type;
        Passengers = passengers;
        IsDining = isDining;
        Consumption = consumption;
    }
}