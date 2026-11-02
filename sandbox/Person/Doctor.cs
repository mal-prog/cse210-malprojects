class Program
{
    static void Main()
    {
        Person myPerson = new Person("John", "Doe", 30, 238);

        Console.WriteLine(myPerson.GetPersonInformation());

        myPerson.DisplayPersonInformation();
        Police myPolice = new Police("Jane", "Smith", 35, 123, "Detective");

        // myPolice.DisplayPersonInformation();
        Console.WriteLine(myPolice.GetPoliceInformation());

        Doctor myDoctor = new Doctor("Emily", "Johnson", 40, 456, "Cardiologist");
        Console.WriteLine(myDoctor.GetDoctorInformation());     
    }
}