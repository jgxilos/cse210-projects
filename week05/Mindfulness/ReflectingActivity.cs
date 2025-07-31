using System;
using System.Collections.Generic;
using System.Threading;

namespace Mindfulness
{
    public class ReflectingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?"
        };

        public ReflectingActivity() : base("Reflecting",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        {
        }

        public override void Run()
        {
            DisplayStartingMessage();
            string prompt = GetRandomPrompt();
            Console.WriteLine($"\n--- Prompt ---\n{prompt}");
            ShowCountDown(5);

            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            while (DateTime.Now < endTime)
            {
                string question = GetRandomQuestion();
                Console.WriteLine($"\n--- Question ---\n{question}");
                ShowSpinner(3);
            }
            DisplayEndingMessage();
        }

        private string GetRandomPrompt() => _prompts[new Random().Next(_prompts.Count)];
        private string GetRandomQuestion() => _questions[new Random().Next(_questions.Count)];
    }
}