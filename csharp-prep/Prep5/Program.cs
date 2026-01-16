using System;

class Program
{
    static void Main(string[] args)
    {
        Displaywelcomemessage();

        string userName = Promptusername();
        int usernumber = Promptusernumber();

        int squarednumber = Squarenumber(usernumber);

        int birthyear;
        Promptuserbirthyear(out birthyear);

        Displayresult(userName, squarednumber, birthyear);
    }

    static void Displaywelcomemessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string Promptusername()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int Promptusernumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    static void Promptuserbirthyear(out int birthyear)
    {
        Console.Write($"Please enter the year you are born: ");
        birthyear = int.Parse(Console.ReadLine());
    }

    static int Squarenumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void Displayresult(string name, int square, int birthyear)
    {
        Console.WriteLine($"{name}, the square of your number is {square}.");
        Console.WriteLine($"{name}, you will turn {2026 - birthyear} years old this year");
    }
}
