using Newtonsoft.Json;

namespace Lab_3.Domain.Utils;

public static class CarParser
{
    public static Car ParseFromJson(string json)
    {
        return JsonConvert.DeserializeObject<Car>(json);
    }
}