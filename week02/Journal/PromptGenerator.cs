using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>();
    private Random _random = new Random();

    public PromptGenerator()
    {
        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("How did I see the Lord's hand in my life today?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I had to do one thing today, what would it be?");
        _prompts.Add("What personal accomplishment did I achieve today?");
        _prompts.Add("What situation surprised me today?");
    }

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}