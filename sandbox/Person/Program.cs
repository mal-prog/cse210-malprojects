class Program
{    

    static void DisplayPersonInformation(Person person)
    {
        if (person is Doctor d)
            Console.WriteLine(d.GetDoctorInformation());
        else if (person is Police p)
            Console.WriteLine(p.GetPoliceInformation());
        else
            Console.WriteLine(person.GetPersonInformation());

    }
    static void Main()
    {
        Person myPerson = new Person("John", "Doe", 30, 180.5);

        // Console.WriteLine(myPerson.GetPersonInformation());

        Police myPolice = new Police("Jane", "Smith", 35, 150.2, "Gun");

        // myPolice.DisplayPoliceInformation();
        // Console.WriteLine(myPolice.GetPersonInformation());

        Doctor myDoctor = new Doctor("Alice", "Johnson", 40, 130.8, "Stethoscope");
        // Console.WriteLine(myDoctor.GetDoctorInformation());

        List<Person> myPeople = new List<Person>();

        myPeople.Add(myPerson);
        myPeople.Add(myPolice);
        myPeople.Add(myDoctor); 

        foreach (Person person in myPeople)
        {
            DisplayPersonInformation(person);
            // Console.WriteLine(person.GetPersonInformation());
            // if(person is Doctor d)
            // {
            //     Console.WriteLine(d.GetDoctorInformation());
            // }
        }
    }
}
