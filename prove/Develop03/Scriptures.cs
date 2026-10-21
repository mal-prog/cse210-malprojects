class Scripture
{
    List<Word> _words;
    // TODO: Add scripture reference

    public Scripture(string bookName, int chapter, int verse, string text)
    {
        // Add scripture ref here. Use bookName, chapter, and verse to create scripture ref
        _words = ConvertToWords(text);
    }

    public Scripture(string bookName, int chapter, int startVerse, int endVerse, string text)
    {
        
    }

    public void ShowScripture()
    {
        foreach(Word word in _words)
        {
            word.Display();
        }
    }
// ConvertToWords will convert the paragraph in "text" to list of words. This list is returned
    private List<Word> ConvertToWords(string text)
    {
        List<Word> tempWords = new List<Word>();

        string[] words = text.Split(' ');
        foreach (string word in text.Split(' '))
        {
            Word tempWord = new Word(word);
            tempWords.Add(tempWord);
        }
        
        return tempWords;
    }
}
