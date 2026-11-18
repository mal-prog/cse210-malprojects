
public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    private const int PointsPerLevel = 1000;

    private static readonly string[] _ranks =
    {
        "Novice Seeker",
        "Faithful Apprentice",
        "Steadfast Disciple",
        "Valiant Servant",
        "Ninja Unicorn",
        "Celestial Champion"
    };

    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": Console.WriteLine("Keep going on your Eternal Quest. Goodbye!"); break;
                default: Console.WriteLine("Please enter a number from 1 to 6."); break;
            }
        }
    }

    private int GetLevel()
    {
        return Math.Max(_score, 0) / PointsPerLevel + 1;
    }

    private string GetRank()
    {
        int index = Math.Min(GetLevel() - 1, _ranks.Length - 1);
        return _ranks[index];
    }

    public void DisplayPlayerInfo()
    {
        int toNext = PointsPerLevel - (Math.Max(_score, 0) % PointsPerLevel);
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Level {GetLevel()} - {GetRank()} ({toNext} points to next level)");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal (bad habit - lose points)");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine() ?? "";

        if (type != "1" && type != "2" && type != "3" && type != "4")
        {
            Console.WriteLine("That isn't a valid goal type.");
            return;
        }

        string name = ReadText("What is the name of your goal? ");
        string description = ReadText("What is a short description of it? ");
        int points = ReadNumber(type == "4"
            ? "How many points should you LOSE each time? "
            : "What is the amount of points associated with this goal? ");

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                int target = ReadNumber("How many times does this goal need to be accomplished for a bonus? ");
                int bonus = ReadNumber("What is the bonus for accomplishing it that many times? ");
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case "4":
                _goals.Add(new NegativeGoal(name, description, points));
                break;
        }

        Console.WriteLine("Goal created!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("Create a goal first.");
            return;
        }

        Console.WriteLine("The goals are:");
        ListGoalNames();
        int index = ReadNumber("Which goal did you accomplish? ") - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("That isn't a valid goal number.");
            return;
        }

        int levelBefore = GetLevel();

        // Polymorphism: each goal type decides how many points it's worth.
        int earned = _goals[index].RecordEvent();
        _score += earned;

        if (earned > 0)
        {
            Console.WriteLine($"Congratulations! You have earned {earned} points!");
        }
        else if (earned < 0)
        {
            Console.WriteLine($"You lost {-earned} points.");
        }

        Console.WriteLine($"You now have {_score} points.");

        if (GetLevel() > levelBefore)
        {
            Console.WriteLine();
            Console.WriteLine("*************************************");
            Console.WriteLine($"  LEVEL UP! You are now Level {GetLevel()}!");
            Console.WriteLine($"  New rank: {GetRank()}");
            Console.WriteLine("*************************************");
        }
    }

    public void SaveGoals()
    {
        string fileName = ReadText("What is the filename for the goal file? ");

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine($"Saved {_goals.Count} goals to {fileName}.");
    }

    public void LoadGoals()
    {
        string fileName = ReadText("What is the filename for the goal file? ");

        if (!File.Exists(fileName))
        {
            Console.WriteLine($"Could not find {fileName}.");
            return;
        }

        string[] lines = File.ReadAllLines(fileName);
        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;

            string[] typeSplit = lines[i].Split(':', 2);
            string type = typeSplit[0];
            string[] parts = typeSplit[1].Split('|');

            string name = parts[0];
            string description = parts[1];
            int points = int.Parse(parts[2]);

            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(name, description, points, bool.Parse(parts[3])));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(name, description, points, int.Parse(parts[3])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(name, description, points,
                        int.Parse(parts[4]), int.Parse(parts[3]), int.Parse(parts[5])));
                    break;
                case "NegativeGoal":
                    _goals.Add(new NegativeGoal(name, description, points, int.Parse(parts[3])));
                    break;
            }
        }

        Console.WriteLine($"Loaded {_goals.Count} goals from {fileName}.");
    }

    // Input helpers keep the program from crashing on bad input.
    private string ReadText(string prompt)
    {
        string input = "";
        while (string.IsNullOrWhiteSpace(input))
        {
            Console.Write(prompt);
            input = (Console.ReadLine() ?? "").Replace("|", "/").Trim();
        }
        return input;
    }

    private int ReadNumber(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int value) && value >= 0)
            {
                return value;
            }
            Console.WriteLine("Please enter a whole number (0 or more).");
        }
    }
}
