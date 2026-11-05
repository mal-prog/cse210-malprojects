using System;
using System.Collections.Generic;
using System.IO;

// EXTRA (exceeds requirements): tracks how many times each activity was
// done and total seconds spent, and saves/loads it from a text file.
public class ActivityLog
{
    private string _fileName;
    private Dictionary<string, int> _counts;
    private Dictionary<string, int> _seconds;

    public ActivityLog(string fileName)
    {
        _fileName = fileName;
        _counts = new Dictionary<string, int>();
        _seconds = new Dictionary<string, int>();
    }

    public void Record(string activityName, int seconds)
    {
        if (!_counts.ContainsKey(activityName))
        {
            _counts[activityName] = 0;
            _seconds[activityName] = 0;
        }
        _counts[activityName]++;
        _seconds[activityName] += seconds;
    }

    public void Save()
    {
        using (StreamWriter writer = new StreamWriter(_fileName))
        {
            foreach (string name in _counts.Keys)
            {
                writer.WriteLine($"{name}|{_counts[name]}|{_seconds[name]}");
            }
        }
    }

    public void Load()
    {
        if (!File.Exists(_fileName)) return;

        foreach (string line in File.ReadAllLines(_fileName))
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3 &&
                int.TryParse(parts[1], out int count) &&
                int.TryParse(parts[2], out int seconds))
            {
                _counts[parts[0]] = count;
                _seconds[parts[0]] = seconds;
            }
        }
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine("Activity Log");
        Console.WriteLine("------------");

        if (_counts.Count == 0)
        {
            Console.WriteLine("No activities completed yet.");
        }
        else
        {
            int totalSeconds = 0;
            foreach (string name in _counts.Keys)
            {
                Console.WriteLine($"{name}: {_counts[name]} time(s), {_seconds[name]} seconds total");
                totalSeconds += _seconds[name];
            }
            Console.WriteLine();
            Console.WriteLine($"Total mindful time: {totalSeconds / 60} min {totalSeconds % 60} sec");
        }

        Console.WriteLine();
        Console.Write("Press enter to return to the menu.");
        Console.ReadLine();
    }
}
