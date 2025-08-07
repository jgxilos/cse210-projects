public class SimpleGoal : Goal
{
    private bool _isComplete;

    // Public property to access the completion status
    public bool IsCompleted 
    {
        get => _isComplete;
        set => _isComplete = value;
    }

    public SimpleGoal(string name, string description, int points) 
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
        }
    }

    // Overwrite the IsComplete() method of the base class
    public override bool IsComplete()
    {
        return IsCompleted; // Using public property
    }

    public override string GetDetailsString()
    {
        return IsCompleted ? $"[X] {_shortName}: {_description}" : $"[ ] {_shortName}: {_description}";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName},{_description},{_points},{IsCompleted}";
    }
}