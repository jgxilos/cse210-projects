using System;

public class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();

        Console.WriteLine("Welcome to the Journal Program!");
        
        while (true)
        {
            ShowMenu();
            int choice = GetChoice();

            switch (choice)
            {
                case 1:
                    WriteEntry(journal, promptGen);
                    break;
                case 2:
                    journal.DisplayAll();
                    break;
                case 3:
                    LoadJournal(journal);
                    break;
                case 4:
                    SaveJournal(journal);
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }

    private static void ShowMenu()
    {
        Console.WriteLine("\nPlease select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.Write("\nWhat would you like to do? ");
    }

    private static int GetChoice()
    {
        string input = Console.ReadLine();
        if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 5)
        {
            return choice;
        }
        return 0;
    }

    private static void WriteEntry(Journal journal, PromptGenerator promptGen)
    {
        string prompt = promptGen.GetRandomPrompt();
        Console.WriteLine($"\n{prompt}");
        Console.Write("> ");
        string response = Console.ReadLine();
        
        string date = DateTime.Now.ToString("MM/dd/yyyy");
        Entry newEntry = new Entry(date, prompt, response);
        journal.AddEntry(newEntry);
    }

    private static void SaveJournal(Journal journal)
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
        Console.WriteLine("Journal saved successfully.");
    }

    private static void LoadJournal(Journal journal)
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();
        try
        {
            journal.LoadFromFile(filename);
            Console.WriteLine("Journal loaded successfully.");
        }
        catch (Exception)
        {
            Console.WriteLine("Error loading file. Please check the filename.");
        }
    }
}