using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        ActivityLog log = new ActivityLog("mindfulness_log.txt");
        log.Load();

        // Created once so prompt "no-repeat" tracking lasts the whole session
        List<Activity> activities = new List<Activity>
        {
            new BreathingActivity(),
            new ReflectingActivity(),
            new ListingActivity(),
            new GroundingActivity()
        };

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Start grounding activity");
            Console.WriteLine("  5. View activity log");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (int.TryParse(choice, out int option) && option >= 1 && option <= activities.Count)
            {
                Activity activity = activities[option - 1];
                activity.Run();
                log.Record(activity.GetName(), activity.GetDuration());
                log.Save();
            }
            else if (choice == "5")
            {
                log.Display();
            }
            else if (choice == "6")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number from 1 to 6.");
                Thread.Sleep(2000);
            }
        }
    }
}
