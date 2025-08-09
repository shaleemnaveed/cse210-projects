using System.Text.Json.Serialization;
public class ChecklistGoal : Goal
{
    // Attributes:
    [JsonInclude]
    private int _amountCompleted;

    [JsonInclude]
    private int _target;

    [JsonInclude]
    private int _bonus;

    // Constructors:
    public ChecklistGoal() : base()
    {
    }
    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
    }

    // Methods:
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
        return 0;
    }
    protected override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }
    public override string GetDetailsString()
    {
        char ch = IsComplete() ? 'X' : ' ';
        return $"[{ch}] {_shortName} ({_description}) -- Currently Completed: {_amountCompleted}/{_target}";
    }
}