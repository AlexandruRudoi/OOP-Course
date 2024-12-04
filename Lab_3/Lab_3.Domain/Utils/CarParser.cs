using Newtonsoft.Json;

namespace Lab_3.Domain.Utils;

public static class CarParser
{
    /// <summary>
    ///     Parses a JSON string and converts it into a <see cref="Car" /> object.
    /// </summary>
    /// <param name="json">The JSON string representing a car.</param>
    /// <returns>A <see cref="Car" /> object populated with data from the JSON string.</returns>
    /// <exception cref="ArgumentException">
    ///     Thrown if the "Passengers" property in the JSON contains an invalid value.
    /// </exception>
    public static Car ParseFromJson(string json)
    {
        var car = JsonConvert.DeserializeObject<Car>(json);

        if (car.Passengers != "PEOPLE" && car.Passengers != "ROBOTS")
            throw new ArgumentException($"Invalid Passengers value: {car.Passengers}");

        return car;
    }
}