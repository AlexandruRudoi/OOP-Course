namespace Lab_3.Domain;

public interface IDineable
{
    /// <summary>
    ///     Serves dinner to passengers in the car with the specified ID.
    /// </summary>
    /// <param name="carId">The ID of the car whose passengers will be served dinner.</param>
    void ServeDinner(string carId);
}