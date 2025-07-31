using System;

namespace Mindfulness
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1. Start breathing activity");
                Console.WriteLine("2. Start reflecting activity");
                Console.WriteLine("3. Start listing activity");
                Console.WriteLine("4. Quit");
                Console.Write("\nSelect a choice from the menu: ");

                int choice = int.Parse(Console.ReadLine());
                Activity activity = null;

                switch (choice)
                {
                    case 1:
                        activity = new BreathingActivity();
                        break;
                    case 2:
                        activity = new ReflectingActivity();
                        break;
                    case 3:
                        activity = new ListingActivity();
                        break;
                    case 4:
                        running = false;
                        break;
                }

                if (activity != null)
                {
                    activity.Run();
                }
            }
        }
    }
}