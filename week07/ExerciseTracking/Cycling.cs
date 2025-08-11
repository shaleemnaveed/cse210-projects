public class Cycling : Activity
{
    // Attributes:
    private double _speed;

    // Constructors:
    public Cycling(string date, int length, double speed) : base(date, length)
    {
        _speed = speed;
    }

    // Methods:
    protected override double CalculateDistance()
    {
        return _speed * (_length / 60.0);
    }
    protected override double CalculateSpeed()
    {
        return _speed;
    }
}