using System;
using System.Collections.Generic;

// Picks random items without repeating any until every item
// has been used once in the current session ("shuffle bag").
public class PromptPicker
{
    private List<string> _items;
    private List<string> _remaining;
    private Random _random;

    public PromptPicker(List<string> items)
    {
        _items = new List<string>(items);
        _remaining = new List<string>();
        _random = new Random();
    }

    public string Next()
    {
        if (_remaining.Count == 0)
        {
            _remaining.AddRange(_items);
        }

        int index = _random.Next(_remaining.Count);
        string item = _remaining[index];
        _remaining.RemoveAt(index);
        return item;
    }
}
