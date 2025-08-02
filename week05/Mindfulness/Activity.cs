public class Activity
{
    // Attributes to hold activity details
    protected string _name;
    protected string _description;
    protected int _duration;

    // Constructor to initialize activity with name and description
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Display introductory message and ask user for session duration
    public void DisplayStartingMessage()
    {
        Console.Write($"\nWelcome to the {_name}.\n\n{_description}\n\nHow long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
    }

    // Display ending message with a spinner
    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell Done!!");
        ShowSpinner(10);
        Console.WriteLine($"\nYou have completed {_duration} seconds of {_name}.");
        ShowSpinner(10);
        Console.Clear();
    }

    // Show animated spinner for given seconds
    protected void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string> { "|", "/", "-", "\\", "|", "/", "-", "\\" };
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            if (i >= animationStrings.Count) i = 0;
            Console.Write(animationStrings[i]);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            i++;
        }
    }

    // Show countdown from a given number of seconds
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
