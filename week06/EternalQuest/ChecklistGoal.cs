// Class representing a checklist goal requiring multiple completions with a bonus
public class ChecklistGoal : Goal
{
    // Tracks how many times the goal has been completed
    public int _amountCompleted { get; set; }

    // Number of times the goal must be completed to earn bonus
    public int _target { get; set; }

    // Bonus points awarded when target completions are met
    public int _bonus { get; set; }

    // Default constructor calling base
    public ChecklistGoal() : base()
    {

    }

    // Parameterized constructor initializing base and checklist-specific fields
    public ChecklistGoal(string type, string name, string description, int points, int target, int bonus) : base(type, name, description, points)
    {
        _target = target;
        _bonus = bonus;
    }

    // Records a completion event; increases count and returns points + bonus if complete
    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            _amountCompleted++;
            int total = _points;
            if (IsComplete())
            {
                total += _bonus;
            }
            return total;
        }
        // Goal already complete, no points awarded
        return 0;
    }

    // Checks if goal has reached or exceeded target completion count
    protected override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    // Returns formatted string showing progress and status
    public override string GetDetailsString()
    {
        char ch = IsComplete() ? 'X' : ' ';
        return $"[{ch}] {_shortName} ({_description}) -- Currently Completed: {_amountCompleted}/{_target}";
    }
}