public abstract class Activity
{
    // Attributes:
    protected string _date;
    protected int _length;
    // Constructors:
    public Activity(string date, int length)
    {
        _date = date;
        _length = length;
    }

    // Methods:
    protected abstract double CalculateDistance();
    protected abstract double CalculateSpeed();
    protected double CalculatePace(double distance)
    {
        return _length / distance;
    }
    public void DisplaySummary()
    {
        double distance = CalculateDistance();
        Console.WriteLine($"{_date} {GetType().Name} ({_length} min) - Distance: {distance:F1} miles, Speed: {CalculateSpeed():F1} mph, Pace: {CalculatePace(distance):F1} min per mile");
    }
}