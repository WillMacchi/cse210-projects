using System;

class Program
{
    static void Main()
    {
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference,
            "For God so loved the world that he gave his only begotten Son so that " +
            "whosoever believeth in him should not perish but have everlasting life.");

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type \"quit\" to exit.");

            string input = Console.ReadLine();
            if (input != null && input.Trim().ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);

            if (scripture.IsCompletelyHidden())
                break;
        }
    }
}
