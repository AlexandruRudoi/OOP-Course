namespace Lab_1.Domain;

public class TextData
{
    /// <summary>
    ///     The name of the file being processed.
    /// </summary>
    private string _fileName;

    /// <summary>
    ///     The content of the text file.
    /// </summary>
    private string _text;

    /// <summary>
    ///     The number of vowels in the text.
    /// </summary>
    private int _numberOfVowels;

    /// <summary>
    ///     The number of consonants in the text.
    /// </summary>
    private int _numberOfConsonants;

    /// <summary>
    ///     The total number of letters in the text.
    /// </summary>
    private int _numberOfLetters;

    /// <summary>
    ///     The number of sentences in the text.
    /// </summary>
    private int _numberOfSentences;

    /// <summary>
    ///     The longest word in the text.
    /// </summary>
    private string _longestWord;

    /// <summary>
    ///     Initializes a new instance of the <see cref="TextData"/> class with the specified text and file name.
    /// </summary>
    /// <param name="text">The text content to analyze.</param>
    /// <param name="fileName">The name of the text file.</param>
    public TextData(string text, string fileName)
    {
        _text = text;
        _fileName = fileName;
        ProcessTextData();
    }

    /// <summary>
    ///     Processes the text data to calculate the number of vowels, consonants, letters, sentences, and the longest word.
    /// </summary>
    private void ProcessTextData()
    {
        var vowels = "aeiouAEIOU";
        _numberOfVowels = _text.Count(c => vowels.Contains(c) && char.IsLetter(c));
        _numberOfConsonants = _text.Count(c => char.IsLetter(c) && !vowels.Contains(c));
        _numberOfLetters = _text.Count(char.IsLetter);
        _numberOfSentences = _text.Split(new[] { '.', '!', '?' },
            StringSplitOptions.RemoveEmptyEntries).Length;
        _longestWord = _text.Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
            .OrderByDescending(w => w.Length).FirstOrDefault() ?? string.Empty;
    }

    /// <summary>
    ///     Gets the name of the text file.
    /// </summary>
    /// <returns>The name of the text file.</returns>
    public string GetFilename() => _fileName;

    /// <summary>
    ///     Gets the content of the text.
    /// </summary>
    /// <returns>The text content.</returns>
    public string GetText() => _text;

    /// <summary>
    ///     Gets the number of vowels in the text.
    /// </summary>
    /// <returns>The vowel count.</returns>
    public int GetNumberOfVowels() => _numberOfVowels;

    /// <summary>
    ///     Gets the number of consonants in the text.
    /// </summary>
    /// <returns>The consonant count.</returns>
    public int GetNumberOfConsonants() => _numberOfConsonants;

    /// <summary>
    ///     Gets the total number of letters in the text.
    /// </summary>
    /// <returns>The total letter count.</returns>
    public int GetNumberOfLetters() => _numberOfLetters;

    /// <summary>
    ///     Gets the number of sentences in the text.
    /// </summary>
    /// <returns>The sentence count.</returns>
    public int GetNumberOfSentences() => _numberOfSentences;

    /// <summary>
    ///     Gets the longest word in the text.
    /// </summary>
    /// <returns>The longest word in the text.</returns>
    public string GetLongestWord() => _longestWord;

    /// <summary>
    ///     Returns a formatted string containing information about the text data, including vowel count, consonant count, letter count, sentence count, and longest word.
    /// </summary>
    /// <returns>A formatted string containing the analyzed data of the text.</returns>
    public override string ToString()
    {
        return $"File: {GetFilename()}\n" +
               $"Text: {GetText()}\n" +
               $"Vowels: {GetNumberOfVowels()}\n" +
               $"Consonants: {GetNumberOfConsonants()}\n" +
               $"Letters: {GetNumberOfLetters()}\n" +
               $"Sentences: {GetNumberOfSentences()}\n" +
               $"Longest Word: {GetLongestWord()}\n";
    }
}