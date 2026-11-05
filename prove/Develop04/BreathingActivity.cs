using System;
using System.Threading;

public class BreathingActivity : Activity
{
    private int _inhaleSeconds;
    private int _exhaleSeconds;

    public BreathingActivity()
        : base("Breathing Activity",
               "This activity will help you relax by walking you through breathing in and out slowly. " +
               "Clear your mind and focus on your breathing.")
    {
        _inhaleSeconds = 4;
        _exhaleSeconds = 6;
    }

    protected override void PerformActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (SecondsLeft(endTime) > 0)
        {
            Console.WriteLine();
            ShowBreath("Breathe in... ", Math.Min(_inhaleSeconds, SecondsLeft(endTime)), true);
            Console.WriteLine();

            if (SecondsLeft(endTime) <= 0) break;

            ShowBreath("Breathe out...", Math.Min(_exhaleSeconds, SecondsLeft(endTime)), false);
            Console.WriteLine();
        }
    }

    // Shows a countdown plus a bar that grows (inhale) or shrinks (exhale).
    // Steps start fast and slow down near the end, like a natural breath.
    private void ShowBreath(string label, int seconds, bool inhale)
    {
        if (seconds <= 0) return;

        const int width = 20;
        int totalWeight = width * (width + 1) / 2;   // 1 + 2 + ... + width
        DateTime start = DateTime.Now;

        for (int step = 1; step <= width; step++)
        {
            int filled = inhale ? step : width - step;
            int remaining = Math.Max(1, (int)Math.Ceiling(seconds - (DateTime.Now - start).TotalSeconds));
            string bar = new string('=', filled).PadRight(width);

            Console.Write($"\r{label} {remaining,2}  [{bar}]");

            // Later steps get longer delays -> quick at first, slow at the end
            int delay = seconds * 1000 * step / totalWeight;
            Thread.Sleep(delay);
        }

        string finalBar = new string('=', inhale ? width : 0).PadRight(width);
        Console.Write($"\r{label}     [{finalBar}]");
    }
}
