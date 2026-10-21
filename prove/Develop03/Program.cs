using System;

class Program
{
    static void Main(string[] args)
    {
        /*
         * Creativity and Exceeding Requirements:
         * This program uses the stretch challenge by selecting only words
         * that have not already been hidden. It also uses a scripture with
         * multiple verses and allows the user to type quit at any time.
         */

        Reference reference = new Reference("Proverbs", 3, 5, 6);

        string text =
            "Trust in the Lord with all thine heart and lean not unto thine own understanding. " +
            "In all thy ways acknowledge him and he shall direct thy paths.";

        Scripture scripture = new Scripture(reference, text);

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to hide words or type quit: ");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }

        if (scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("All words are hidden. Great job memorizing!");
        }
    }
}