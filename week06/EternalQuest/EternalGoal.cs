public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) 
        : base(name, description, points) { }

    public override void RecordEvent()
    {
        // Eternal goals always earn points when you sign up.
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString() => 
        $"[ ] {_shortName}: {_description} (Eternal)";

    public override string GetStringRepresentation() => 
        $"EternalGoal:{_shortName},{_description},{_points}";
}