using System;

class Program
{
    static void Main(string[] args)
    {
        Word myWord = new Word("Bubba");
        myWord.Display();
        myWord.Hide();
        Console.WriteLine();
        myWord.Display();
    }
}