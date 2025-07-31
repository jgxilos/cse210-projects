using System;
using System.Collections.Generic;
using System.Threading;

namespace Mindfulness
{
    public class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?"
        };

        private int _count = 0;

        public ListingActivity() : base("Listing",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
        }

        public override void Run()
        {
            DisplayStartingMessage();
            string prompt = GetRandomPrompt();
            Console.WriteLine($"\n--- Prompt ---\n{prompt}");
            ShowCountDown(5);

            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            Console.WriteLine("\nBegin listing items. Press enter after each item.");
            while (DateTime.Now < endTime)
            {
                string item = Console.ReadLine();
                if (string.IsNullOrEmpty(item)) break;
                _count++;
            }
            DisplayEndingMessage();
        }

        private string GetRandomPrompt() => _prompts[new Random().Next(_prompts.Count)];
    }
}