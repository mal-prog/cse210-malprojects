class Menu
{
    public int ProcessMenu()
    {
        int response = 0;

        while (response < 1 || response > 5)
        {
            Console.WriteLine("Welcome to the Journal Program.");
            Console.WriteLine("Create Display, Save, and Read Journal Entries");
            Console.WriteLine("1. Create new journal entry.");
            Console.WriteLine("2. Display Journal.");
            Console.WriteLine("3. Save Journal file.");
            Console.WriteLine("4. Read journal from file.");
            Console.WriteLine("5 . Quit");
            Console.Write(">");

            response = int.Parse(Console.ReadLine());
        }

        return response;

    }
}