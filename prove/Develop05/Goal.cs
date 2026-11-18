
public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    protected Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public string GetName()
    {
        return _shortName;
    }

    protected string GetDescription()
    {
        return _description;
    }

    protected int GetPoints()
    {
        return _points;
    }

    // Records one accomplishment and returns the points earned (can be negative).
    public abstract int RecordEvent();

    public abstract bool IsComplete();

    // Text used to save the goal to a file.
    public abstract string GetStringRepresentation();

    // Text shown in the goal list. Derived classes override this when they
    // need to show more (e.g. checklist progress).
    public virtual string GetDetailsString()
    {
        string box = IsComplete() ? "[X]" : "[ ]";
        return $"{box} {_shortName} ({_description})";
    }

    // Shared helper so every goal saves its fields the same way.
    // A '|' separator lets names and descriptions contain commas.
    protected string BaseFields()
    {
        return $"{_shortName}|{_description}|{_points}";
    }
}
