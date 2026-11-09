class Doctor : Person
{
    private string _tools;

    public Doctor(string firstName, string lastName, int age, double weight, string tools) : base(firstName, lastName, age, weight)
    {
        _tools = tools;
    }


    public override string GetPersonInformation()
    {
        return $"Doctor Tools: {_tools}{base.GetPersonInformation()}";
    }
}