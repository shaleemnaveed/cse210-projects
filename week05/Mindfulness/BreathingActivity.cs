public class BreathingActivity : Activity
{
    // Constructors:
    public BreathingActivity(string name, string description) : base(name, description)
    {
    }

    // Methods:
    public void Run()
    {
        int remainder = _duration % 10;
        _duration -= remainder;
        Console.Clear();
        Console.WriteLine("Get Ready...");
        if (remainder > 0)
        {
            ShowSpinner(remainder);
        }
        else
        {
            ShowSpinner(10);
        }
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("\n\nBreathe in...");
            ShowCountDown(5);
            Console.WriteLine();
            Console.Write("Now Breathe out...");
            ShowCountDown(5);
        }
    }
}