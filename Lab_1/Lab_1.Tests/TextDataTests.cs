using Lab_1.Domain;

namespace Lab_1.Tests;

[TestFixture]
public class TextDataTests
{
    private TextData _textData;
    private string _sampleText;
    private string _fileName;

    [SetUp]
    public void SetUp()
    {
        _sampleText = "Hello, world! This is a test sentence. Testing vowels, consonants, and the longest word.";
        _fileName = "sample.txt";
        _textData = new TextData(_sampleText, _fileName);
    }

    [Test]
    public void Constructor_InitializesCorrectly()
    {
        Assert.That(_textData.GetFilename(), Is.EqualTo(_fileName), "File name was not initialized correctly.");
        Assert.That(_textData.GetText(), Is.EqualTo(_sampleText), "Text content was not initialized correctly.");
    }

    [Test]
    public void GetNumberOfVowels_CorrectlyCountsVowels()
    {
        int expectedVowels = 22;
        Assert.That(_textData.GetNumberOfVowels(), Is.EqualTo(expectedVowels), "Vowel count is incorrect.");
    }

    [Test]
    public void GetNumberOfConsonants_CorrectlyCountsConsonants()
    {
        int expectedConsonants = 47;
        Assert.That(_textData.GetNumberOfConsonants(), Is.EqualTo(expectedConsonants), "Consonant count is incorrect.");
    }

    [Test]
    public void GetNumberOfLetters_CorrectlyCountsTotalLetters()
    {
        int expectedLetters = 69;
        Assert.That(_textData.GetNumberOfLetters(), Is.EqualTo(expectedLetters), "Total letter count is incorrect.");
    }

    [Test]
    public void GetNumberOfSentences_CorrectlyCountsSentences()
    {
        int expectedSentences = 3;
        Assert.That(_textData.GetNumberOfSentences(), Is.EqualTo(expectedSentences), "Sentence count is incorrect.");
    }

    [Test]
    public void GetLongestWord_FindsLongestWord()
    {
        string expectedLongestWord = "consonants";
        Assert.That(_textData.GetLongestWord(), Is.EqualTo(expectedLongestWord), "Longest word is incorrect.");
    }

    [Test]
    public void ToString_ReturnsFormattedString()
    {
        var expectedOutput = $"File: {_fileName}\n" +
                             $"Text: {_sampleText}\n" +
                             $"Vowels: {_textData.GetNumberOfVowels()}\n" +
                             $"Consonants: {_textData.GetNumberOfConsonants()}\n" +
                             $"Letters: {_textData.GetNumberOfLetters()}\n" +
                             $"Sentences: {_textData.GetNumberOfSentences()}\n" +
                             $"Longest Word: {_textData.GetLongestWord()}\n";

        Assert.That(_textData.ToString(), Is.EqualTo(expectedOutput), "Formatted output is incorrect.");
    }
}