using System;
using System.Threading;

// Base class: holds everything every activity shares (name, description,
// duration, starting/ending messages, and the pause animations).
public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetDuration()
    {
        return _duration;
    }

    // Template method: the shared flow is written once here, and each
    // derived class only supplies its own middle section.
    public void Run()
    {
        DisplayStartingMessage();
        PerformActivity();
        DisplayEndingMessage();
    }

    // Each derived activity implements its unique behavior here.
    protected abstract void PerformActivity();

    private void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        _duration = PromptForDuration();

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine();
    }

    private int PromptForDuration()
    {
        while (true)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int seconds) && seconds > 0)
            {
                return seconds;
            }
            Console.WriteLine("Please enter a whole number greater than 0.");
        }
    }

    private void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(4);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(5);
    }

    // Seconds left before the given end time (rounded up, never negative).
    protected int SecondsLeft(DateTime endTime)
    {
        double left = (endTime - DateTime.Now).TotalSeconds;
        return left <= 0 ? 0 : (int)Math.Ceiling(left);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(frames[i % frames.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;
        }
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            string text = i.ToString();
            Console.Write(text);
            Thread.Sleep(1000);
            // Erase the number (handles 2+ digit numbers too)
            Console.Write(new string('\b', text.Length));
            Console.Write(new string(' ', text.Length));
            Console.Write(new string('\b', text.Length));
        }
    }
}
