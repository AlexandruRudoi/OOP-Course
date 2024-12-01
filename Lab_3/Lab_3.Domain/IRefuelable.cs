namespace Lab_3.Domain;

public interface IRefuelable
{
    /// <summary>
    ///     Refuels the car with the specified ID.
    /// </summary>
    /// <param name="carId">The ID of the car to refuel.</param>
    void Refuel(string carId);
}