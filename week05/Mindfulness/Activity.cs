public class Activity
{
    // Attributes:
    protected string _name;
    protected string _description;
    protected int _duration;

    // Constructors:
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Methods:
    public void DisplayStartingMessage()
    {
        Console.Write($"\nWelcome to the {_name}.\n\n{_description}\n\nHow long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell Done!!");
        ShowSpinner(10);
        Console.WriteLine($"\nYou have completed {_duration} seconds of {_name}.");
        ShowSpinner(10);
        Console.Clear();
    }
    protected void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string> { "|", "/", "-", "\\", "|", "/", "-", "\\" };
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            if (i >= animationStrings.Count)
            {
                i = 0;
            }
            Console.Write(animationStrings[i]);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            i++;
        }
    }
    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
