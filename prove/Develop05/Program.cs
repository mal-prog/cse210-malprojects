
// EXCEEDING REQUIREMENTS:
// 1. Leveling system: every 1000 points the user levels up. Each level has a
//    rank title (Novice Seeker -> Faithful Apprentice -> Steadfast Disciple ->
//    Valiant Servant -> Ninja Unicorn -> Celestial Champion). The menu shows the
//    current level, rank, and points needed for the next level, and a
//    "LEVEL UP!" banner is displayed when the user crosses a level.
// 2. Negative goals (NegativeGoal class): a fourth goal type for bad habits.
//    Recording one subtracts points, and the list shows how many times the
//    user has slipped.
// 3. Eternal goals track how many times they've been recorded, shown in the list.
// 4. Recording an already-completed simple or checklist goal awards no points
//    (no farming points from finished goals).
// 5. Input validation: non-numbers and invalid menu or goal choices are
//    rejected instead of crashing the program, and loading a missing file
//    shows a message instead of an error.
// 6. Save file uses '|' as a separator so goal names and descriptions can
//    contain commas.

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to your Eternal Quest!");
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
