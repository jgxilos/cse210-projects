using System;

class Program
{
    static void Main(string[] args)
    {
        //Ask the user for his or her name.
        Console.Write("What is your first name? ");
        string first = Console.ReadLine();

        //Ask the user for his or her last name.
        Console.Write("What is your last name? ");
        string last = Console.ReadLine();

        Console.WriteLine($"Your name is {last}, {first} {last}");
    }
}