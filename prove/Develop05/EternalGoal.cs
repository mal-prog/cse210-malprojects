
public class EternalGoal : Goal
{
    private int _timesRecorded;

    public EternalGoal(string name, string description, int points, int timesRecorded = 0)
        : base(name, description, points)
    {
        _timesRecorded = timesRecorded;
    }

    public override int RecordEvent()
    {
        _timesRecorded++;
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Recorded {_timesRecorded} times";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{BaseFields()}|{_timesRecorded}";
    }
}
