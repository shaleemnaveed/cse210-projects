using System.Text.Json.Serialization;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(SimpleGoal), "SimpleGoal")]
[JsonDerivedType(typeof(ChecklistGoal), "ChecklistGoal")]
[JsonDerivedType(typeof(EternalGoal), "EternalGoal")]
public abstract class Goal
{
    // Attributes:
    [JsonInclude]
    protected string _shortName;      
    [JsonInclude]
    protected string _description;    
    [JsonInclude]
    protected int _points;             

    // Constructors:
    public Goal()
    {
    }
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Methods:
    public string GetName()
    {
        return _shortName;
    }
    public int GetPoints()
    {
        return _points;
    }
    public abstract int RecordEvent();
    protected abstract bool IsComplete();
    public abstract string GetDetailsString();
}