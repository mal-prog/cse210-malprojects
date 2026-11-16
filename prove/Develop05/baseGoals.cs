
class BaseGoal
{
    private string _name;
    
    public BaseGoal()
    {
        GetGoalName();
    }

    private void GetGoalName()
    {
        Console.Write("Please enter the name of your goal: ");
        _name = Console.ReadLine();
    }
    
    public string GetConsoleString()
    {
        return $"Goal name: {_name}";
    }
}