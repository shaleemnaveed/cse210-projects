using System.Text.Json;
using System.Text.Json.Serialization;
public class GoalManager
{
    // Attributes:
    [JsonInclude]
    private List<Goal> _goals;

    [JsonInclude]
    private int _score = 0;

    [JsonInclude]
    private int _rank = 1;

    // Constructors:
    public GoalManager()
    {
        _goals = new List<Goal>();
    }

    // Methods:
    public void Start()
    {
        while (true)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.Write("\nMenu Options:\n 1. Create New Goal\n 2. List Goals\n 3. Save Goals\n 4. Load Goals\n 5. Record Event\n 6. Quit\nSelect a choice from the menu: ");
            int choice = int.Parse(Console.ReadLine());
            while (choice < 1 || choice > 6)
            {
                Console.Write("Invalid Option.\nChoose again: ");
                choice = int.Parse(Console.ReadLine());
            }
            if (choice == 1)
            {
                CreateGoal();
            }
            else if (choice == 2)
            {
                Console.WriteLine("The goals are:");
                ListGoalDetails();
            }
            else if (choice == 3)
            {
                SaveGoals();
            }
            else if (choice == 4)
            {
                LoadGoals();
            }
            else if (choice == 5)
            {
                RecordEvent();
            }
            else if (choice == 6)
            {
                Console.WriteLine("Good job. Keep at it!\n");
                break;
            }
        }
    }
    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"You're at rank {_rank} and you have {_score} points.");
    }
    private void ListGoalNames()
    {
        int count = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{count}. {goal.GetName()}");
            count++;
        }
    }
    private void ListGoalDetails()
    {
        int count = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{count}. {goal.GetDetailsString()}");
            count++;
        }
    }
    private void CreateGoal()
    {
        Goal goal = null;

        Console.Write("The type of Goals are:\n 1. Simple Goal\n 2. Checklist Goal\n 3. Eternal Goal\nWhich type would you like to create? ");
        int choice = int.Parse(Console.ReadLine());
        while (choice < 1 || choice > 3)
        {
            Console.Write("Invalid Goal.\nChoose again: ");
            choice = int.Parse(Console.ReadLine());
        }
        if (choice == 1)
        {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());
            goal = new SimpleGoal(name, description, points);
        }
        if (choice == 2)
        {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            goal = new ChecklistGoal(name, description, points, target, bonus);
        }
        if (choice == 3)
        {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());
            goal = new EternalGoal(name, description, points);
        }
        _goals.Add(goal);
    }
    private void RecordEvent()
    {
        Console.WriteLine("The goals are:");
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;
        while (index < 0 || index >= _goals.Count)
        {
            Console.Write("Invalid Goal.\nChoose again: ");
            index = int.Parse(Console.ReadLine()) - 1;
        }
        int points = _goals[index].RecordEvent();
        _score += points;
        int newRank = (_score / 1000) + 1;
        if (newRank > _rank)
        {
            _rank = newRank;
            Console.WriteLine($"🎉 You leveled up! Your new rank is {_rank}!");
        }
        Console.WriteLine($"Congratulations! You earned {points} points!\nYou now have {_score} points.");
    }
    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file (.json)? ");
        string file = Console.ReadLine();
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true
        };
        string json = JsonSerializer.Serialize(this, options);
        File.WriteAllText(file, json);
        Console.WriteLine("Goals successfully saved.");
    }
    private void LoadGoals()
    {
        _rank = 1;
        _score = 0;
        _goals.Clear();
        Console.Write("What is the filename for the goal file (.json)? ");
        string file = Console.ReadLine();
        while (!File.Exists(file))
        {
            Console.Write("Invalid filename.\nType again (.json): ");
            file = Console.ReadLine();
        }
        var options = new JsonSerializerOptions
        {
            IncludeFields = true
        };
        GoalManager loaded = JsonSerializer.Deserialize<GoalManager>(File.ReadAllText(file), options);
        _rank = loaded._rank;
        _score = loaded._score;
        _goals = loaded._goals;
        Console.WriteLine("Goals successfully loaded.");
    }
}