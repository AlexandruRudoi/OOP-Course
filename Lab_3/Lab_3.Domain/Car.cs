namespace Lab_3.Domain;

public class Car
{
    /// <summary>
    ///     Gets or sets the unique identifier of the car.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    ///     Gets or sets the type of the car (e.g., ELECTRIC or GAS).
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    ///     Gets or sets the type of passengers in the car (e.g., PEOPLE or ROBOTS).
    /// </summary>
    public string Passengers { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether the car's passengers want to dine.
    /// </summary>
    public bool IsDining { get; set; }

    /// <summary>
    ///     Gets or sets the consumption value of the car.
    /// </summary>
    public int Consumption { get; set; }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Car"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the car.</param>
    /// <param name="type">The type of the car.</param>
    /// <param name="passengers">The type of passengers in the car.</param>
    /// <param name="isDining">Whether the passengers want to dine.</param>
    /// <param name="consumption">The consumption value of the car.</param>
    public Car(string id, string type, string passengers, bool isDining, int consumption)
    {
        Id = id;
        Type = type;
        Passengers = passengers;
        IsDining = isDining;
        Consumption = consumption;
    }
}