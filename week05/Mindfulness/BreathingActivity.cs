public class BreathingActivity : Activity
{
    // Constructor
    public BreathingActivity(string name, string description) : base(name, description) { }

    // Run breathing activity: inhale and exhale cycles
    public void Run()
    {
        // Round down duration to nearest multiple of 10
        int remainder = _duration % 10;
        _duration -= remainder;

        Console.Clear();
        Console.WriteLine("Get Ready...");

        // Show short spinner before starting
        ShowSpinner(remainder > 0 ? remainder : 10);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        // Loop until time runs out, showing breathing prompts
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
