using Lab_0.Domain;

namespace Lab_0.Tests
{
    [TestFixture]
    public class JsonReaderTests
    {
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
            Assert.That(result.Count, Is.EqualTo(2));

            // Check details of the first alien species
            Assert.That(result[0].Id, Is.EqualTo(1));
            Assert.IsTrue(result[0].IsHumanoid);
            Assert.That(result[0].Planet, Is.EqualTo("Mars"));
            Assert.That(result[0].Age, Is.EqualTo(100));
            Assert.Contains("Tall", result[0].Traits);
            Assert.Contains("Smart", result[0].Traits);

            // Check details of the second alien species
            Assert.That(result[1].Id, Is.EqualTo(2));
            Assert.IsFalse(result[1].IsHumanoid);
            Assert.That(result[1].Planet, Is.EqualTo("Venus"));
            Assert.That(result[1].Age, Is.EqualTo(50));
            Assert.Contains("Strong", result[1].Traits);
        }

        [Test]
        public void ReadJson_ShouldReturnNull_WhenInvalidJsonIsProvided()
        {
            string malformedJson = @"{ ""input"": [ { ""id"": 1, ""isHumanoid"": true }";

            string tempFilePath = Path.GetTempFileName();
            File.WriteAllText(tempFilePath, malformedJson);

            JsonReader jsonReader = new JsonReader();
            List<AlienSpecies> result = jsonReader.ReadJson(tempFilePath);

            Assert.IsNull(result);
        }
    }
}