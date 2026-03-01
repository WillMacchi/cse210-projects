using System;
using System.Threading;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _topics = new List<string>()
    {
        "List things you’re grateful for.",
        "List people who inspire you.",
        "List things that make you happy."
    };

    public ListingActivity()
        : base("Listing Activity", "This activity will help you list positive things in your life.")
    { }

    public override void Run()
    {
        Start();

        Random random = new Random();
        string topic = _topics[random.Next(_topics.Count)];
        Console.WriteLine(topic);

        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        List<string> responses = new List<string>();

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            responses.Add(Console.ReadLine());
        }

        Console.WriteLine($"You listed {responses.Count} items!");
        End();
    }
}