using System.Text.Json;
using Lab_0.Domain;

namespace Lab_0.Tests;

[TestFixture]
public class ViewTests
{
    private string _tempDirectory;

    [SetUp]
    public void Setup()
    {
        _tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(_tempDirectory);
    }

    [TearDown]
    public void TearDown()
    {
        if (Directory.Exists(_tempDirectory))
            Directory.Delete(_tempDirectory, true);
        
    }

    [Test]
    public void WriteToFile_ShouldCreateFile_WithExpectedContent()
    {
        // Arrange
        var view = new View();
        var fileName = "test_universe.json";
        var universeName = "hitchHiker";
        var testIndividuals = new List<AlienSpecies>
        {
            new AlienSpecies
            {
                Id = 1,
                IsHumanoid = true,
                Planet = "Betelgeuse",
                Age = 42,
                Traits = new List<string> { "EXTRA_ARMS", "EXTRA_HEAD" }
            }
        };

        // Act
        var filePath = Path.Combine(_tempDirectory, fileName);
        view.WriteToFile(filePath, universeName, testIndividuals);

        // Assert
        Assert.IsTrue(File.Exists(filePath), "Output file was not created.");

        var jsonOutput = File.ReadAllText(filePath);
        var expectedOutput = new
        {
            name = universeName,
            individuals = testIndividuals
        };

        var expectedJson = JsonSerializer.Serialize(expectedOutput, new JsonSerializerOptions { WriteIndented = true });
        Assert.That(jsonOutput, Is.EqualTo(expectedJson), "Output file content does not match expected JSON.");
    }
}