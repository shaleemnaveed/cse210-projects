public class Swimming : Activity
{
    // Attributes:
    private int _laps;

    // Constructors:
    public Swimming(string date, int length, int laps) : base(date, length)
    {
        _laps = laps;
    }

    // Methods:
    protected override double CalculateDistance()
    {
        return _laps * 50 / 1000 * 0.62;
    }
    protected override double CalculateSpeed()
    {
        return CalculateDistance() / _length * 60;
    }
}