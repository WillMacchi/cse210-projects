using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Select Difficulty:");
        Console.WriteLine("1 - Easy");
        Console.WriteLine("2 - Medium");
        Console.WriteLine("3 - Hard");

        int wordsToHide = 3;
        string inputDifficulty = Console.ReadLine();

        if (inputDifficulty == "1")
            wordsToHide = 1;
        else if (inputDifficulty == "2")
            wordsToHide = 3;
        else if (inputDifficulty == "3")
            wordsToHide = 5;

        Reference reference = new Reference("John", 3, 16);

        Scripture scripture = new Scripture(reference,
            "For God so loved the world that he gave his only begotten Son");

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine("\nPress ENTER to hide words or type 'quit'");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(wordsToHide);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nProgram Finished.");
    }
}