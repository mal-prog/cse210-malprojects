using System;
using System.Collections.Generic;

// EXTRA activity (exceeds requirements): the 5-4-3-2-1 grounding technique.
public class GroundingActivity : Activity
{
    private List<string> _steps;

    public GroundingActivity()
        : base("Grounding Activity",
               "This activity will help you calm down and return to the present moment by using your five senses. " +
               "Take your time and really notice each thing.")
    {
        _steps = new List<string>
        {
            "Notice 5 things you can SEE around you.",
            "Notice 4 things you can FEEL (your chair, your clothes, the air).",
            "Notice 3 things you can HEAR.",
            "Notice 2 things you can SMELL.",
            "Notice 1 thing you can TASTE."
        };
    }

    protected override void PerformActivity()
    {
        // Split the session evenly across the five senses
        int secondsPerStep = Math.Max(1, GetDuration() / _steps.Count);
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        foreach (string step in _steps)
        {
            if (SecondsLeft(endTime) <= 0) break;

            Console.WriteLine();
            Console.Write($"> {step} ");
            ShowSpinner(Math.Min(secondsPerStep, SecondsLeft(endTime)));
        }
        Console.WriteLine();
    }
}
