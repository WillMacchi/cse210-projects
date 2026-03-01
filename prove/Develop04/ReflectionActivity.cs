using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time you helped someone.",
        "Think of a time you showed courage.",
        "Think of a time you learned something important."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this meaningful to you?",
        "What did you learn about yourself?",
        "How can you apply this in the future?"
    };

    public ReflectionActivity()
        : base("Reflection Activity", "This activity will help you reflect on personal experiences.")
    { }

    public override void Run()
    {
        Start();

        Random random = new Random();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            string prompt = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine(prompt);
            Thread.Sleep(2000);

            foreach (var question in _questions)
            {
                Console.WriteLine(question);
                Thread.Sleep(2000);
            }
        }

        End();
    }
}