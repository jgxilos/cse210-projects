using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for the percentage of qualification
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();
        int percentage = int.Parse(input);

        // Determine the corresponding letter according to the percentage
        string letter = "";
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the symbol (+ or -) according to the last percentage digit
        string sign = "";
        int lastDigit = percentage % 10;

        // For the letters B, C and D, we apply the normal rules
        if (letter != "A" && letter != "F")
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        // For the letter A, only a - is allowed if the last digit is < 3
        else if (letter == "A" && lastDigit < 3)
        {
            sign = "-";
        }

        // Display the final grade
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // Determine if the student passed the class
        if (percentage >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}