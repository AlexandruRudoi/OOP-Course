using Lab_1.Domain;

namespace Lab_1.Tests;

[TestFixture]
public class FileReaderTests
{
    private FileReader _fileReader;
    private string _testFilePath;
    private string _invalidFilePath;

    [SetUp]
    public void SetUp()
    {
        _fileReader = new FileReader();
        _testFilePath = "testfile.txt";
        _invalidFilePath = "nonexistentfile.txt";

        File.WriteAllText(_testFilePath, "This is a sample text file for testing purposes.");
    }

    [TearDown]
    public void TearDown()
    {
        if (File.Exists(_testFilePath)) File.Delete(_testFilePath);
    }

    [Test]
    public void ReadFileIntoString_ValidFilePath_ReturnsFileContent()
    {
        var result = _fileReader.ReadFileIntoString(_testFilePath);

        Assert.IsNotNull(result, "Expected file content but got null.");
        Assert.That(result.Trim(), Is.EqualTo("This is a sample text file for testing purposes."),
            "File content does not match expected text.");
    }

    [Test]
    public void ReadFileIntoString_InvalidFilePath_ReturnsNullAndLogsError()
    {
        using var sw = new StringWriter();
        Console.SetOut(sw);

        var result = _fileReader.ReadFileIntoString(_invalidFilePath);

        Assert.IsNull(result, "Expected null for an invalid file path.");
        Assert.IsTrue(sw.ToString().Contains("Error reading file"), "Expected an error message for a missing file.");
    }

    // [Test] // Uncomment this test to try an unauthorized access scenario manually
    // public void ReadFileIntoString_UnauthorizedAccess_ReturnsNullAndLogsError()
    // {
    //     // Set up a file with restricted access to simulate an UnauthorizedAccessException
    //     // Note: This can be tricky to automate in a unit test and may require special permissions.
    //     string restrictedFilePath = "restrictedFile.txt";
    //     File.WriteAllText(restrictedFilePath, "Restricted content.");
    //     File.SetAttributes(restrictedFilePath, FileAttributes.ReadOnly);

    //     using var sw = new StringWriter();
    //     Console.SetOut(sw);

    //     var result = _fileReader.ReadFileIntoString(restrictedFilePath);

    //     Assert.IsNull(result);
    //     Assert.IsTrue(sw.ToString().Contains("Error reading file"), "Expected an error message for unauthorized access.");

    //     // Clean up
    //     File.SetAttributes(restrictedFilePath, FileAttributes.Normal);
    //     File.Delete(restrictedFilePath);
    // }
}