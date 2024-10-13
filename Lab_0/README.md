# Alien Species Classification System

This project is part of an Object-Oriented Programming (OOP) lab assignment. The goal is to create a system that reads JSON data representing alien species, classifies them based on attributes such as their planet of origin, age, and traits, and outputs the results to separate JSON files.

## Project Structure

- **`AlienSpecies` Class**: Represents individual alien species, encapsulating their details like ID, planet, age, humanoid status, and traits, along with a classification method that assigns species to a fictional universe.
- **`JsonReader` Class**: Responsible for reading a JSON file that contains an array of alien species and deserializing it into a list of `AlienSpecies` objects.
- **`View` Class**: Handles writing the classified alien species to specific output JSON files, grouping them by their classified universe.
- **Unit Tests for `AlienSpecies` and `JsonReader`**: Includes tests to validate both the classification logic in `AlienSpecies` and the JSON reading functionality in `JsonReader`.

## Classes

### `AlienSpecies`

The `AlienSpecies` class models an alien species with the following properties:

- `Id` (int): Unique identifier for the alien species.
- `IsHumanoid` (bool?): Indicates if the species is humanoid (nullable).
- `Planet` (string): The planet where the alien species originates.
- `Age` (int?): The age of the alien species (nullable).
- `Traits` (List<string>): A list of traits that describe the species (e.g., "Tall", "Strong").

It also provides a method `PrintSpecies()` to display the alien's information in a formatted way and a method `Classify()` that classifies the alien species into a fictional universe based on its attributes.

#### **Classification Method (`Classify()`)**:

The `Classify` method applies a weighted scoring system to match the alien species to one of several fictional universes, such as:
- **Star Wars Universe** (e.g., Wookie, Ewok)
- **Marvel Universe** (e.g., Asgardian)
- **Hitchhiker's Universe** (e.g., Vogon, Betelgeusian)
- **Lord of the Rings Universe** (e.g., Elf, Dwarf)

The classification is based on attributes like the species' planet, age, humanoid status, and traits. The system assigns a score to each universe, and the one with the highest score is returned as the classification.

**Example Usage**:
```csharp
AlienSpecies species = new AlienSpecies {
    Id = 1,
    IsHumanoid = true,
    Planet = "Asgard",
    Age = 1500,
    Traits = new List<string> { "Blonde", "Tall" }
};

string classification = species.Classify();
Console.WriteLine(classification); // Outputs: "Marvel Universe (Asgardian)"
```

### `JsonReader`
The `JsonReader` class handles reading and parsing a JSON file that contains an array of alien species. It provides a method `ReadJson(string filePath)` that reads the file and deserializes the "input" field from the JSON into a list of `AlienSpecies`.

Key Functionality:

- Reads a JSON file from the specified file path.
- Extracts the `"input"` array, which contains a list of alien species.
- Deserializes the JSON array into a list of `AlienSpecies` objects.
- Returns `null` if an error occurs during reading or parsing.

**Example Usage**:
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

### `View`

The `View` class is responsible for writing the classified alien species into separate JSON files based on their fictional universe. It groups individuals by their classification and writes them into four output files:
- `hitchhiker.json`
- `marvel.json`
- `rings.json` (for Lord of the Rings)
- `starwars.json`

**Key Method**:
- `WriteToFile(string fileName, string universeName, List<AlienSpecies> individuals)`: Writes the list of classified individuals into a specified JSON file with the appropriate universe name.

**Example Usage**:
```csharp
View view = new View();
view.WriteToFile("hitchhiker.json", "hitchHiker", hitchhikerList);
```

### Unit Tests

#### Unit Tests for `AlienSpecies`

Unit tests are provided using the NUnit framework to validate the classification logic within the `AlienSpecies` class.

Tests include:
- `Classify_ShouldReturnWookie_ForKashyyykHairyTallSpecies`: Verifies that an alien species from Kashyyyk with the traits "HAIRY" and "TALL" is classified as a Wookie from the Star Wars universe.
- `Classify_ShouldReturnEwok_ForEndorShortHairySpecies`: Verifies that an alien species from Endor with the traits "SHORT" and "HAIRY" is classified as an Ewok from the Star Wars universe.
- Additional tests ensure the correct classification for species from the Marvel, Hitchhiker’s, and Lord of the Rings universes.

**Example NUnit Test for Classification**:
```csharp
[Test]
public void Classify_ShouldReturnWookie_ForKashyyykHairyTallSpecies()
{
    var species = new AlienSpecies
    {
        Id = 1,
        IsHumanoid = false,
        Planet = "Kashyyyk",
        Age = 300,
        Traits = new List<string> { "HAIRY", "TALL" }
    };

    var classification = species.Classify();
    Assert.AreEqual("Star Wars Universe (Wookie)", classification);
}
```

#### Unit Tests for `JsonReader`

Unit tests validate that the `JsonReader` can correctly read and deserialize a JSON file containing alien species.

Tests include:
- `ReadJson_ShouldReturnAlienSpeciesList_WhenValidJsonIsProvided`: Ensures that valid JSON is correctly deserialized into a list of `AlienSpecies`.
- `ReadJson_ShouldReturnNull_WhenInvalidJsonIsProvided`: Checks that the method handles invalid JSON correctly by returning `null`.

**Example NUnit Test for `JsonReader`**:
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

### Example Output

The system generates four JSON files in the `output` directory based on the classification of alien species. An example of `hitchhiker.json` is shown below:

```json
{
  "name": "hitchHiker",
  "individuals": [
    {
      "id": 3,
      "isHumanoid": true,
      "planet": "Betelgeuse",
      "age": 59,
      "traits": [
        "EXTRA_ARMS",
        "EXTRA_HEAD"
      ]
    }
  ]
}
```

---

### License
Feel free to use, modify, and distribute this project for any purpose.