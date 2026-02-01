using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            journal.DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.GeneratePrompt();
                    break;

                case "2":
                    journal.DisplayJournal();
                    break;

                case "3":
                    Console.Write("Enter filename to load: ");
                    journal.LoadFile(Console.ReadLine());
                    break;

                case "4":
                    Console.Write("Enter filename to save: ");
                    journal.SaveFile(Console.ReadLine());
                    break;

                case "5":
                    journal.Exit();
                    running = false;
                    break;
            }
        }
    }
}
