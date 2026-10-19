

class Word
{
     private string _word;
    private bool _hidden;
     
     public Word(string word)
    {
        _word = word;
        _hidden = false;
    }

    public void Hide()
    {
        _hidden = true;
    }
    public bool IsHidden()
    {
        return _hidden;
    }

    public void Display()
    {
        Console.WriteLine($"{_word}");
    }

    public string GetWordString()
    {
        string returnString = "";
        if (_hidden)
        {
            for(int i = 0; i < _word.Length; i++)
            {
                returnString += '_';
            }
        }
        else
        {
            returnString = _word;
        }  
        
        return returnString; 
    }
} 