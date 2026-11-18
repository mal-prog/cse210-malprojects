
public class NegativeGoal : Goal
{
    private int _timesSlipped;

    public NegativeGoal(string name, string description, int points, int timesSlipped = 0)
        : base(name, description, points)
    {
        _timesSlipped = timesSlipped;
    }

    public override int RecordEvent()
    {
        _timesSlipped++;
        Console.WriteLine("Oops! That habit cost you some points. You've got this next time.");
        return -GetPoints();
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[!] {GetName()} ({GetDescription()}) -- Lose {GetPoints()} pts each time, slipped {_timesSlipped} times";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{BaseFields()}|{_timesSlipped}";
    }
}
