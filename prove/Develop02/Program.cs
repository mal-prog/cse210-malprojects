using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    private string _date;
    private string _prompt;
    private string _response;
    private string _mood;

    public Entry(string date, string prompt, string response, string mood)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine("----------------------------");
    }

    public string GetSaveData()
    {
        return $"{_date}~|~{_prompt}~|~{_response}~|~{_mood}";
    }

    public static Entry LoadFromFile(string line)
    {
        string[] parts = line.Split("~|~");

        return new Entry(parts[0], parts[1], parts[2], parts[3]);
    }
}

class Journal
{
    private List<Entry> _entries = new List<Entry>();

    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one goal I have for tomorrow?"
    };

    private Random _random = new Random();

    public void WriteEntry()
    {
        string prompt = _prompts[_random.Next(_prompts.Count)];

        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine() ?? "";

        Console.Write("How would you describe your mood today? ");
        string mood = Console.ReadLine() ?? "";

        string date = DateTime.Now.ToString("MM/dd/yyyy");

        Entry entry = new Entry(date, prompt, response, mood);
        _entries.Add(entry);

        Console.WriteLine("Your entry was saved.");
    }

    public void DisplayJournal()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("There are no entries yet.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveJournal()
    {
        Console.Write("Enter the filename to save to: ");
        string filename = Console.ReadLine() ?? "";

        List<string> lines = new List<string>();

        foreach (Entry entry in _entries)
        {
            lines.Add(entry.GetSaveData());
        }

        File.WriteAllLines(filename, lines);
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadJournal()
    {
        Console.Write("Enter the filename to load: ");
        string filename = Console.ReadLine() ?? "";

        if (!File.Exists(filename))
        {
            Console.WriteLine("That file could not be found.");
            return;
        }

        _entries.Clear();

        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                _entries.Add(Entry.LoadFromFile(line));
            }
        }

        Console.WriteLine("Journal loaded successfully.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creativity: In addition to the required date, prompt, and response,
        // this program also saves the user's mood for each journal entry.

        Journal journal = new Journal();
        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine();
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal");
            Console.WriteLine("4. Load the journal");
            Console.WriteLine("5. Quit");
            Console.Write("Select an option: ");

            choice = Console.ReadLine() ?? "";

            if (choice == "1")
            {
                journal.WriteEntry();
            }
            else if (choice == "2")
            {
                journal.DisplayJournal();
            }
            else if (choice == "3")
            {
                journal.SaveJournal();
            }
            else if (choice == "4")
            {
                journal.LoadJournal();
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}