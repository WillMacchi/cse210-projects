using System;

class Program
{
    static void Main(string[] args)
    {
        
        Random generator = new Random();
        int MagicNumber = generator.Next(1,51);

        int guess = -1;

        while (guess != MagicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (MagicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (MagicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
        
    }


}