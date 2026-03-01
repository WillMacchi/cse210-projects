using System;

public abstract class Activity
{
    protected int Duration { get; private set; }
    protected string Name { get; private set; }
    protected string Description { get; private set; }

    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"--- {Name} ---");
        Console.WriteLine(Description);
        Console.Write("How long, in seconds, would you like for your session? ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");
        Console.WriteLine();
    }

    public abstract void Run();

    public void End()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        Console.WriteLine($"You completed the {Name} for {Duration} seconds!");
        Console.WriteLine();
        Console.WriteLine("Press Enter to return to the main menu...");
        Console.ReadLine();
    }
}