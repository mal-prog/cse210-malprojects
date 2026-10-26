class Police : Person
{
    private string _weapons;

    public Police(string firstName, string lastName, int age, double weight, string weapons) 
    : base(firstName, lastName, age, weight)
    {
        _weapons = weapons;
    }

    public void DisplayPoliceInformation()
    {
        Console.WriteLine($"{_firstName} {_lastName} is a police officer with {(_weapons ?? "no")} weapons.");
    }
}