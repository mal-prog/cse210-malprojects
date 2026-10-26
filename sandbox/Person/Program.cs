class Program
{
    static void Main()
    {
        Person myPerson = new Person("Bob", "Floyd", 56, 238);

        myPerson.DisplayPersonInformation();

        Police myPolice = new Police("Lance", "Bob", 34, 186, "Taser");
        
        myPolice.DisplayPoliceInformation();
    }
}
