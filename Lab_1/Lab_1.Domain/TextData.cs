namespace Lab_1.Domain;

public class TextData
{
    private string _fileName;
    private string _text;
    private int _numberOfVowels;
    private int _numberOfConsonants;
    private int _numberOfLetters;
    private int _numberOfSentences;
    private string _longestWord;

    public TextData(string text, string fileName)
    {
        this._text = text;
        this._fileName = fileName;
        ProcessTextData();
    }

    private void ProcessTextData()
    {
        string vowels = "aeiouAEIOU";
        this._numberOfVowels = this._text.Count(c => vowels.Contains(c));
        this._numberOfConsonants = this._text.Count(c => char.IsLetter(c) && !vowels.Contains(c));
        this._numberOfLetters = this._text.Count(char.IsLetter);
        this._numberOfSentences = this._text.Split(new[] { '.', '!', '?' },
            StringSplitOptions.RemoveEmptyEntries).Length;
        this._longestWord = this._text.Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
            .OrderByDescending(w => w.Length).FirstOrDefault() ?? string.Empty;
    }

    // Getters
    public string GetFilename() => _fileName;
    public string GetText() => _text;
    public int GetNumberOfVowels() => _numberOfVowels;
    public int GetNumberOfConsonants() => _numberOfConsonants;
    public int GetNumberOfLetters() => _numberOfLetters;
    public int GetNumberOfSentences() => _numberOfSentences;
    public string GetLongestWord() => _longestWord;

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