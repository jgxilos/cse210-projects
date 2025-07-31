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
            ShowCountDown(5);
        }

        public virtual void DisplayEndingMessage()
        {
            Console.WriteLine($"\n\nYou've completed the {_name} Activity for {_duration} seconds!");
            ShowSpinner(3);
            Console.WriteLine("\nGreat job! Take a moment to reflect on your experience.");
            ShowCountDown(3);
        }

        // Método común para todas las actividades
        public virtual void Run() { }

        protected int GetDurationFromUser()
        {
            Console.Write("\nHow long, in seconds, would you like for your session? ");
            return int.Parse(Console.ReadLine());
        }

        protected void ShowSpinner(int seconds)
        {
            string[] spinner = { "|", "/", "-", "\\" };
            DateTime endTime = DateTime.Now.AddSeconds(seconds);
            while (DateTime.Now < endTime)
            {
                foreach (string symbol in spinner)
                {
                    Console.Write(symbol);
                    Thread.Sleep(250);
                    Console.Write("\b \b");
                }
            }
        }

        protected void ShowCountDown(int seconds)
        {
            for (int i = seconds; i >= 0; i--)
            {
                Console.Write(i.ToString());
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
    }
}