using System;
using System.Threading;

namespace Mindfulness
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing", 
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        public override void Run()
        {
            DisplayStartingMessage();
            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            while (DateTime.Now < endTime)
            {
                Console.WriteLine("\nBreathe in...");
                ShowCountDown(4);
                Console.WriteLine("Now breathe out...");
                ShowCountDown(6);
            }
            DisplayEndingMessage();
        }
    }
}