using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] wordArray = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberOfWords)
    {
        List<Word> visibleWords = _words
            .Where(word => !word.IsHidden())
            .ToList();

        for (int i = 0; i < numberOfWords && visibleWords.Count > 0; i++)
        {
            int randomIndex = _random.Next(visibleWords.Count);
            Word wordToHide = visibleWords[randomIndex];

            wordToHide.Hide();
            visibleWords.RemoveAt(randomIndex);
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }

    public string GetDisplayText()
    {
        List<string> displayedWords = new List<string>();

        foreach (Word word in _words)
        {
            displayedWords.Add(word.GetDisplayText());
        }

        return $"{_reference.GetDisplayText()} {string.Join(" ", displayedWords)}";
    }
}