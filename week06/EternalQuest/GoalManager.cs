using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        while (true)
        {
            DisplayPlayerInfo();
            DisplayMenu();
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1: CreateGoal(); break;
                    case 2: ListGoalDetails(); break;
                    case 3: SaveGoals(); break;
                    case 4: LoadGoals(); break;
                    case 5: RecordEvent(); break;
                    case 6: return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    private void DisplayMenu()
    {
        Console.WriteLine("\nMenu Options:");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. Quit");
        Console.Write("\nSelect a choice from the menu: ");
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("\nWhich type of goal would you like to create? ");

        if (int.TryParse(Console.ReadLine(), out int type))
        {
            Console.Write("\nWhat is the name of your goal? ");
            string name = Console.ReadLine() ?? "";
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine() ?? "";

            switch (type)
            {
                case 1:
                    if (!AskForPoints(out int points)) break;
                    _goals.Add(new SimpleGoal(name, description, points));
                    break;
                case 2:
                    if (!AskForPoints(out int eternalPoints)) break;
                    _goals.Add(new EternalGoal(name, description, eternalPoints));
                    break;
                case 3:
                    if (!AskForChecklistParameters(out int checklistPoints, out int target, out int bonus)) break;
                    _goals.Add(new ChecklistGoal(name, description, checklistPoints, target, bonus));
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }
        }
    }

    private bool AskForPoints(out int points)
    {
        Console.Write("What is the amount of points associated with this goal? ");
        return int.TryParse(Console.ReadLine(), out points);
    }

    private bool AskForChecklistParameters(out int points, out int target, out int bonus)
    {
        points = target = bonus = 0; // Initialize variables out

        if (!AskForPoints(out points)) return false;
        Console.Write("How many times does this goal need to be accomplished? ");
        if (!int.TryParse(Console.ReadLine(), out target)) return false;
        Console.Write("What is the bonus points for completing the target? ");
        return int.TryParse(Console.ReadLine(), out bonus);
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("\nGoals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        ListGoalsForSelection();
        Console.Write("\nWhich goal did you accomplish? ");
        
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= _goals.Count)
        {
            Goal selectedGoal = _goals[index - 1];
            selectedGoal.RecordEvent();
            
            int pointsEarned = selectedGoal.Points;
            
            // Bonus para ChecklistGoal
            if (selectedGoal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                pointsEarned += checklistGoal.Bonus;
                Console.WriteLine($"Congratulations! You earned a bonus of {checklistGoal.Bonus} points!");
            }
            
            _score += pointsEarned;
            Console.WriteLine($"\nYou earned {pointsEarned} points!");
            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    private void ListGoalsForSelection()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine() ?? "goals.txt";

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
                writer.WriteLine($"Score:{_score}");
            }
            Console.WriteLine($"Goals saved successfully to {filename}!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine() ?? "goals.txt";

        if (!File.Exists(filename))
        {
            Console.WriteLine($"File {filename} not found.");
            return;
        }

        _goals.Clear();
        foreach (string line in File.ReadAllLines(filename))
        {
            if (line.StartsWith("Score:"))
            {
                _score = int.Parse(line.Split(':')[1]);
                continue;
            }

            // Split the line into type and data
            string[] parts = line.Split(new[] { ':' }, 2);
            if (parts.Length < 2) continue;

            string type = parts[0];
            string data = parts[1];

            // Split the data by commas
            string[] fields = data.Split(',');
            switch (type)
            {
                case "SimpleGoal":
                    if (fields.Length >= 4)
                    {
                        string name = fields[0];
                        string description = fields[1];
                        int points = int.Parse(fields[2]);
                        bool isComplete = bool.Parse(fields[3]);
                        _goals.Add(new SimpleGoal(name, description, points) { IsCompleted = isComplete });
                    }
                    break;
                case "EternalGoal":
                    if (fields.Length >= 3)
                    {
                        string name = fields[0];
                        string description = fields[1];
                        int points = int.Parse(fields[2]);
                        _goals.Add(new EternalGoal(name, description, points));
                    }
                    break;
                case "ChecklistGoal":
                    if (fields.Length >= 6)
                    {
                        string name = fields[0];
                        string description = fields[1];
                        int points = int.Parse(fields[2]);
                        int target = int.Parse(fields[3]);
                        int bonus = int.Parse(fields[4]);
                        int completed = int.Parse(fields[5]);
                        ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
                        goal.AmountCompleted = completed;
                        _goals.Add(goal);
                    }
                    break;
            }
        }
        Console.WriteLine($"Goals loaded successfully from {filename}!");
    }
}