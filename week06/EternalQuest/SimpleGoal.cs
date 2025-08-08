// Class representing a simple one-time goal
public class SimpleGoal : Goal
{
    // Indicates whether this simple goal has been completed
    public bool _isComplete { get; set; } = false;

    // Default constructor calling base
    public SimpleGoal() : base()
    {

    }

    // Parameterized constructor passing data to base Goal class
    public SimpleGoal(string type, string name, string description, int points) : base(type, name, description, points)
    {

    }

    // Marks the goal as complete and returns points (only once)
    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        // Already complete, no points
        return 0;
    }

    // Returns completion status
    protected override bool IsComplete()
    {
        return _isComplete;
    }

    // Returns formatted string showing status and goal info
    public override string GetDetailsString()
    {
        char ch = IsComplete() ? 'X' : ' ';
        return $"[{ch}] {_shortName} ({_description})";
    }
}
