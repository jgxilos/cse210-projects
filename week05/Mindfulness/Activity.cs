using System;
using System.Threading;

namespace Mindfulness
{
    public class Activity
    {
        protected string _name;
        protected string _description;
        protected int _duration;

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public virtual void DisplayStartingMessage()
        {
            Console.WriteLine($"Welcome to the {_name} Activity.\n\n{_description}\n");
            _duration = GetDurationFromUser();
            Console.WriteLine("\nPrepare to begin...");
            ShowSpinner(5);  //Show spinner animation for 5 seconds
        }

        public virtual void DisplayEndingMessage()
        {
            Console.WriteLine($"\n\nYou've completed the {_name} Activity for {_duration} seconds!");
            Console.WriteLine("\nGreat job! Take a moment to reflect on your experience.");
            ShowSpinner(5);  // Show spinner animation for 5 seconds before returning to the menu
        }

        public virtual void Run()
        {
            // Default implementation (empty)
        }

        protected int GetDurationFromUser()
        {
            Console.Write("\nHow long, in seconds, would you like for your session? ");
            return int.Parse(Console.ReadLine());
        }

        protected void ShowSpinner(int seconds)
        {
            string[] spinner = { "/", "-", "\\", "|" };  // Sequence to create the spinning effect
            DateTime endTime = DateTime.Now.AddSeconds(seconds);
            while (DateTime.Now < endTime)
            {
                foreach (string symbol in spinner)
                {
                    Console.Write($"\r{symbol}");  // Use \r to overwrite the same line
                    Thread.Sleep(250);
                }
            }
            Console.Write("\r ");  // Clean up the line after the animation
        }

        protected void ShowCountDown(int seconds)
        {
            for (int i = seconds; i >= 0; i--)
            {
                Console.Write($"\r{i}");  // Use \r to overwrite the same line
                Thread.Sleep(1000);
            }
            Console.Write("\r ");  // Clear the line after the countdown
        }
    }
}