using System;

class Program
{
    static void Main(string[] args)
    {
        // Display a welcome message to the user
        DisplayWelcomeMessage();

        // Prompt the user for their name and store it
        string userName = PromptUserName();

        // Prompt the user for their favorite number and store it
        int userNumber = PromptUserNumber();

        // Calculate the square of the entered number
        int squaredNumber = SquareNumber(userNumber);

        // Display the final result to the user
        DisplayResult(userName, squaredNumber);
    }

    /// Displays a welcome message to the user.
    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    /// Prompts the user to enter their name and returns it.
    /// <returns>The user's name as a string.</returns>
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    /// Prompts the user to enter their favorite number and returns it as an integer.
    /// <returns>The user's favorite number as an integer.</returns>
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    /// Squares the provided number.
    /// <param name="number">The number to be squared.</param>
    /// <returns>The square of the input number.</returns>
    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    /// Displays the result to the user, showing their name and the square of their number.
    /// <param name="name">The user's name.</param>
    /// <param name="square">The squared value of the user's favorite number.</param>
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}