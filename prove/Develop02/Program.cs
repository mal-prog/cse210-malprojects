using System;

class Program
{
    static void Main(string[] args)
    {
        Menu myMenu = new Menu();

        int response = 0;
        JournalEntry newEntry = new JournalEntry();

        while (response != 5)    
        {
            response=myMenu.ProcessMenu();
            switch(response)
            {   
                case 1:
                    Console.WriteLine("Create");
                        newEntry.CreateJournalEntry();
                        break;
                case 2:
                    Console.WriteLine("Display");
                    newEntry.CreateJournalEntry();
                    break;
                case 3:
                     Console.WriteLine("Save");
                     newEntry.CreateJournalEntry();
                    break;
                case 4:
                    Console.WriteLine("Write");
                    newEntry.CreateJournalEntry();
                    break;
            }
        }
    }
}