// Abstract base class representing a generic Goal
public abstract class Goal
{
    // Properties shared by all goals
    public string _type { get; set; }           // Type of goal (SimpleGoal, ChecklistGoal, EternalGoal)
    public string _shortName { get; set; }      // Short name/title of the goal
    public string _description { get; set; }    // Description of the goal
    public int _points { get; set; }             // Points awarded for completing the goal

    // Default constructor
    public Goal()
    {
        
    }

    // Parameterized constructor to initialize attributes
    public Goal(string type, string name, string description, int points)
    {
        _type = type;
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Returns the type of the goal
    public string GetGoalType()
    {
        return _type;
    }

    // Returns the short name of the goal
    public string GetName()
    {
        return _shortName;
    }

    // Returns the points associated with the goal
    public int GetPoints()
    {
        return _points;
    }

    // Abstract method to record a goal event and return points earned
    public abstract int RecordEvent();

    // Abstract method to determine if the goal is complete
    protected abstract bool IsComplete();

    // Abstract method to get a string representing goal details for display
    public abstract string GetDetailsString();
}