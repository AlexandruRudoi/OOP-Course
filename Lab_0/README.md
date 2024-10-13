# Alien Species Classification System

This project is part of an Object-Oriented Programming (OOP) lab assignment. The goal is to create a system that reads JSON data representing alien species and classifies them based on attributes such as their planet of origin, age, and traits.

## Project Structure

- **`AlienSpecies` Class**: Represents individual alien species, encapsulating their details like ID, planet, age, humanoid status, and traits.
- **`JsonReader` Class**: Responsible for reading a JSON file that contains an array of alien species and deserializing it into a list of `AlienSpecies` objects.
- **Unit Tests for `JsonReader`**: Includes tests that validate the functionality of the `JsonReader` class, ensuring it can handle valid and malformed JSON inputs.

## Classes

### `AlienSpecies`

The `AlienSpecies` class models an alien species with the following properties:

- `Id` (int): Unique identifier for the alien species.
- `IsHumanoid` (bool?): Indicates if the species is humanoid (nullable).
- `Planet` (string): The planet where the alien species originates.
- `Age` (int?): The age of the alien species (nullable).
- `Traits` (List<string>): A list of traits that describe the species (e.g., "Tall", "Strong").

Additionally, it provides a method `PrintSpecies()` to display the alien's information in a formatted way.

**Example Usage:**
```csharp
AlienSpecies species = new AlienSpecies {
    Id = 1,
    IsHumanoid = true,
    Planet = "Mars",
    Age = 200,
    Traits = new List<string> { "Tall", "Strong" }
};

species.PrintSpecies();
```

### `JsonReader`
The `JsonReader` class handles the reading and parsing of a JSON file that contains an array of alien species. It provides a method `ReadJson(string filePath)` that reads the file and deserializes the "input" field from the JSON into a list of `AlienSpecies`.

Key Functionality:

- `Reads` a JSON file from the given file path.
- Extracts the `"input"` array, which contains a list of alien species.
- Deserializes the JSON array into a list of `AlienSpecies` objects.
- Returns `null` if an error occurs during reading or parsing.

**Example Usage:**
```csharp
JsonReader jsonReader = new JsonReader();
List<AlienSpecies> alienSpeciesList = jsonReader.ReadJson("path/to/input.json");

if (alienSpeciesList != null)
{
    foreach (var species in alienSpeciesList)
    {
        species.PrintSpecies();
    }
}
```

### `Unit Tests for JsonReader`
Unit tests are provided using the NUnit framework to validate the behavior of the `JsonReader` class. The following tests are implemented:

- `ReadJson_ShouldReturnAlienSpeciesList_WhenValidJsonIsProvided`: This test checks that the `JsonReader` can successfully parse a valid JSON file and return a list of alien species.

- `ReadJson_ShouldReturnNull_WhenInvalidJsonIsProvided`: This test checks that the `JsonReader` correctly handles invalid JSON (e.g., missing closing brackets) by returning `null`.

These tests ensure that the `JsonReader` class behaves correctly in both normal and error scenarios.

**Example NUnit Test for Valid JSON:**
```csharp
[Test]
public void ReadJson_ShouldReturnAlienSpeciesList_WhenValidJsonIsProvided()
{
    string mockJson = @"
    {
        ""input"": [
            {
                ""id"": 1,
                ""isHumanoid"": true,
                ""planet"": ""Mars"",
                ""age"": 100,
                ""traits"": [""Tall"", ""Smart""]
            },
            {
                ""id"": 2,
                ""isHumanoid"": false,
                ""planet"": ""Venus"",
                ""age"": 50,
                ""traits"": [""Strong""]
            }
        ]
    }";

    string tempFilePath = Path.GetTempFileName();
    File.WriteAllText(tempFilePath, mockJson);

    JsonReader jsonReader = new JsonReader();
    List<AlienSpecies> result = jsonReader.ReadJson(tempFilePath);

    Assert.IsNotNull(result);
    Assert.AreEqual(2, result.Count);
    Assert.AreEqual(1, result[0].Id);
    Assert.AreEqual("Mars", result[0].Planet);
    Assert.Contains("Tall", result[0].Traits);
}
```