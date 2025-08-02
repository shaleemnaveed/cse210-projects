public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private static PromptManager _promptManager;

    // Constructor
    public ListingActivity(string name, string description) : base(name, description) { }

    // Run listing activity
    public void Run()
    {
        Console.Clear();
        Console.WriteLine("Get Ready...");
        ShowSpinner(10);

        Console.WriteLine("List as many responses as you can to the following prompt:");
        GetRandomPrompt();

        Console.Write("You may begin in...");
        ShowCountDown(5);

        // Capture user responses
        List<string> items = GetListFromUser();
        _count = items.Count;

        Console.WriteLine($"You listed {_count} items.");
    }

    // Show a unique random prompt
    private void GetRandomPrompt()
    {
        if (_promptManager == null)
        {
            _promptManager = new PromptManager(_prompts);
        }
        Console.WriteLine($" --- {_promptManager.GetNextUniquePrompt()} --- ");
    }

    // Get list of responses from user for the duration of the activity
    private List<string> GetListFromUser()
    {
        List<string> responses = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        Console.WriteLine();

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            responses.Add(input);
        }

        return responses;
    }
}
