using System.Text.Json.Serialization;
public class SimpleGoal : Goal
{
    // Attributes:
    [JsonInclude]
    private bool _isComplete = false;
    
    // Constructors:
    public SimpleGoal() : base()
    {
    }
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    // Methods:
    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        return 0;
    }
    protected override bool IsComplete()
    {
        return _isComplete;
    }
    public override string GetDetailsString()
    {
        char ch = IsComplete() ? 'X' : ' ';
        return $"[{ch}] {_shortName} ({_description})";
    }
}
