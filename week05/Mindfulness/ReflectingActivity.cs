public class ReflectingActivity : Activity
{
    // Attributes:
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    // Constructors:
    public ReflectingActivity(string name, string description) : base(name, description)
    {
    }

    // Methods:
    public void Run()
    {
        Console.Clear();
        Console.WriteLine("Get Ready...");
        ShowSpinner(10);
        Console.WriteLine("Consider the following prompt:");
        DisplayPrompt();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in...");
        ShowCountDown(5);
        Console.Clear();
        DisplayQuestions();
    }
    private static readonly Random random = new Random();
    private string GetRandomPrompt()
    {
        int index = random.Next(_prompts.Count);
        return $" --- {_prompts[index]} --- ";
    }
    private string GetRandomQuestion()
    {
        int index = random.Next(_questions.Count);
        return $"> {_questions[index]} ";
    }
    private void DisplayPrompt()
    {
        Console.WriteLine(GetRandomPrompt());
    }
    private void DisplayQuestions()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write(GetRandomQuestion());
            ShowSpinner(10);
            Console.WriteLine();
        }
    }
}