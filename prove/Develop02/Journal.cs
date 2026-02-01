using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _journal = new List<Entry>();
    private List<string> _prompts = new List<string>();

    public Journal()
    {
        _prompts = new List<string>(File.ReadAllLines("prompts.txt"));
    }

    public void DisplayMenu()
    {
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display journal");
        Console.WriteLine("3. Load journal from file");
        Console.WriteLine("4. Save journal to file");
        Console.WriteLine("5. Exit");
        Console.Write("Choose an option: ");
    }

    public Entry GeneratePrompt()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];

        Entry entry = new Entry();
        entry._date = DateTime.Now.ToShortDateString();
        entry._prompt = prompt;

        Console.WriteLine(prompt);
        Console.Write("> ");
        entry._entry = Console.ReadLine();

        _journal.Add(entry);
        return entry;
    }

    public void DisplayJournal()
    {
        foreach (Entry entry in _journal)
        {
            entry.Display();
        }
    }

    public List<Entry> LoadFile(string fileName)
    {
        _journal.Clear();
        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            Entry entry = new Entry();
            entry._date = parts[0];
            entry._prompt = parts[1];
            entry._entry = parts[2];

            _journal.Add(entry);
        }

        return _journal;
    }

    public void SaveFile(string fileName)
    {
        using (StreamWriter output = new StreamWriter(fileName))
        {
            foreach (Entry entry in _journal)
            {
                output.WriteLine($"{entry._date}|{entry._prompt}|{entry._entry}");
            }
        }
    }

    public void Exit()
    {
        Console.WriteLine("Goodbye!");
    }
}
