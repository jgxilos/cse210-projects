using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    public static void Main()
    {
        // Load scripts from file
        List<Scripture> scriptures = LoadScripturesFromFile("scriptures.txt");
        
        // If there are no writings loaded, use a default set
        if (scriptures.Count == 0)
        {
            scriptures.Add(new Scripture(new Reference("Proverbs", 3, 5, 6), 
                "Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths."));
            
            scriptures.Add(new Scripture(new Reference("John", 3, 16), 
                "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."));
            
            scriptures.Add(new Scripture(new Reference("Alma", 37, 37), 
                "By small means the Lord does great things"));
        }

        // Select a quote from the scriptures at random
        Random random = new Random();
        Scripture selectedScripture = scriptures[random.Next(scriptures.Count)];
        
        const int WORDS_TO_HIDE_PER_TURN = 3;

        while (!selectedScripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.Write("\nPress enter to continue or type 'quit' to finish: ");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            selectedScripture.HideRandomWords(WORDS_TO_HIDE_PER_TURN);
        }

        Console.Clear();
        Console.WriteLine(selectedScripture.GetDisplayText());
        Console.WriteLine("\nAll words hidden! Press any key to exit.");
        Console.ReadKey();
    }

    private static List<Scripture> LoadScripturesFromFile(string filename)
    {
        List<Scripture> scriptures = new List<Scripture>();
        
        try
        {
            string[] lines = File.ReadAllLines(filename);
            
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                
                // Expected format: Book:Chapter:Verse-EndVerse:Text
                string[] parts = line.Split(':');
                
                if (parts.Length < 4) continue;
                
                string book = parts[0];
                int chapter = int.Parse(parts[1]);
                
                // Process verses
                string[] verseParts = parts[2].Split('-');
                int startVerse = int.Parse(verseParts[0]);
                int? endVerse = null;
                
                if (verseParts.Length > 1)
                {
                    endVerse = int.Parse(verseParts[1]);
                }
                
                Reference reference;
                if (endVerse.HasValue)
                {
                    reference = new Reference(book, chapter, startVerse, endVerse.Value);
                }
                else
                {
                    reference = new Reference(book, chapter, startVerse);
                }
                
                string text = string.Join(":", parts.Skip(3).Take(parts.Length - 3));
                scriptures.Add(new Scripture(reference, text));
            }
        }
        catch (Exception)
        {
            // Do nothing, we will use the default scripture quotations.
        }
        
        return scriptures;
    }
}