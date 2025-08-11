public class Running : Activity
{
    // Attributes:
    private double _distance;

    // Constructors:
    public Running(string date, int length, double distance) : base(date, length)
    {
        _distance = distance;
    }

    // Methods:
    protected override double CalculateDistance()
    {
        return _distance;
    }
    protected override double CalculateSpeed()
    {
        return _distance / _length * 60;
    }
}