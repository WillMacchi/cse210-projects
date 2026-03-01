using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity", "This activity will help you relax by guiding your breathing.")
    { }

    public override void Run()
    {
        Start();

        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in... ");
            Thread.Sleep(3000);
            Console.WriteLine();
            Console.Write("Breathe out... ");
            Thread.Sleep(3000);
            Console.WriteLine();
        }

        End();
    }
}