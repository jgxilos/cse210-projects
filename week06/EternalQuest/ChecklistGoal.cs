public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    public int Bonus { get; private set; }

    public int AmountCompleted // Public property
    {
        get => _amountCompleted;
        set => _amountCompleted = value;
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonus) 
        : base(name, description, points)
    {
        _target = target;
        Bonus = bonus;
        _amountCompleted = 0;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString() => 
        $"{(IsComplete() ? "[X]" : "[ ]")} {_shortName}: {_description} ({_amountCompleted}/{_target})";

    public override string GetStringRepresentation() => 
        $"ChecklistGoal:{_shortName},{_description},{_points},{_target},{Bonus},{_amountCompleted}";
}