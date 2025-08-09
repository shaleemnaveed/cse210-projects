public class EternalGoal : Goal
{
    // Constructors:
    public EternalGoal() : base()
    {
    }
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    // Methods:
    public override int RecordEvent()
    {
        return _points;
    }
    protected override bool IsComplete()
    {
        return false;
    }
    public override string GetDetailsString()
    {
        char ch = IsComplete() ? 'X' : '∞';
        return $"[{ch}] {_shortName} ({_description})";
    }
}