using Newtonsoft.Json;

namespace Lab_3.Domain.Utils;

public static class CarParser
{
    public static Car ParseFromJson(string json)
    {
        var car = JsonConvert.DeserializeObject<Car>(json);

        // Validate expected values
        if (car.Passengers != "PEOPLE" && car.Passengers != "ROBOTS")
        {
            throw new ArgumentException($"Invalid Passengers value: {car.Passengers}");
        }

        return car;
    }
}