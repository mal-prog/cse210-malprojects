using System;

class Program
{
    static void Main(string[] args)
    {
        string firstName;
        string lastName;
        Console.Write("Please enter your first name: ");
        firstName = Console.ReadLine();
        Console.Write("Please enter your last name: ");
        lastName = Console.ReadLine();

        Console.WriteLine($"{firstName} {lastName}");
    }
}