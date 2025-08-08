using System.Text.Json;
using System.IO;
using System.Collections.Generic;

// Class to manage all goals and player state, including saving/loading and UI menu
public class GoalManager
{
    // List of goals currently tracked
    private List<Goal> _goals;

    // Player score points accumulated
    private int _score = 0;

    // Player rank, increases based on score milestones
    private int _rank = 1;

    // Constructor initializes the goals list
    public GoalManager()
    {
        _goals = new List<Goal>();
    }

    // Main loop method that displays menu and responds to user input
    public void Start()
    {
        while (true)
        {
            Console.WriteLine();
            DisplayPlayerInfo();

            Console.Write("\nMenu Options:\n 1. Create New Goal\n 2. List Goals\n 3. Save Goals\n 4. Load Goals\n 5. Record Event\n 6. Quit\nSelect a choice from the menu: ");

            // Parse user menu selection
            int choice = int.Parse(Console.ReadLine());

            // Validate menu choice
            while (choice < 1 || choice > 6)
            {
                Console.Write("Invalid Option.\nChoose again: ");
                choice = int.Parse(Console.ReadLine());
            }

            // Perform action based on user choice
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
                break;  // Exit the loop and end program
            }
        }
    }

    // Displays the current rank and total points
    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"You're at rank {_rank} and you have {_score} points.");
    }

    // Lists goal names only (for choosing which to record event on)
    private void ListGoalNames()
    {
        int count = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{count}. {goal.GetName()}");
            count++;
        }
    }

    // Lists detailed info about each goal including progress/status
    private void ListGoalDetails()
    {
        int count = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{count}. {goal.GetDetailsString()}");
            count++;
        }
    }

    // Prompts the user to create a new goal of a selected type and adds it to the list
    private void CreateGoal()
    {
        Goal goal = null;

        Console.Write("The type of Goals are:\n 1. Simple Goal\n 2. Checklist Goal\n 3. Eternal Goal\nWhich type would you like to create? ");
        int choice = int.Parse(Console.ReadLine());

        // Validate choice
        while (choice < 1 || choice > 3)
        {
            Console.Write("Invalid Goal.\nChoose again: ");
            choice = int.Parse(Console.ReadLine());
        }

        // For each goal type, prompt user for relevant information
        if (choice == 1)
        {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());
            goal = new SimpleGoal("SimpleGoal", name, description, points);
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
            goal = new ChecklistGoal("ChecklistGoal", name, description, points, target, bonus);
        }
        if (choice == 3)
        {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());
            goal = new EternalGoal("EternalGoal", name, description, points);
        }

        // Add the new goal to the goals list
        _goals.Add(goal);
    }

    // Records an event for a chosen goal, updating points and rank
    private void RecordEvent()
    {
        Console.WriteLine("The goals are:");
        ListGoalNames();

        Console.Write("Which goal did you accomplish? ");

        int index = int.Parse(Console.ReadLine()) - 1;

        // Validate chosen goal index
        while (index < 0 || index >= _goals.Count)
        {
            Console.Write("Invalid Goal.\nChoose again: ");
            index = int.Parse(Console.ReadLine()) - 1;
        }

        // Record event on the selected goal and get points earned
        int points = _goals[index].RecordEvent();

        // Update total score
        _score += points;

        // Calculate new rank based on score milestones (every 1000 points)
        int newRank = (_score / 1000) + 1;

        // Notify user if rank has increased
        if (newRank > _rank)
        {
            _rank = newRank;
            Console.WriteLine($"🎉 You leveled up! Your new rank is {_rank}!");
        }

        // Show points earned and current total
        Console.WriteLine($"Congratulations! You earned {points} points!\nYou now have {_score} points.");
    }

    // Saves the current goals, score, and rank to a JSON file
    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file (.json)? ");
        string file = Console.ReadLine();

        // Serialize each goal individually to JSON strings
        List<string> goalsJson = new List<string>();
        foreach (Goal goal in _goals)
        {
            string jsonGoal = JsonSerializer.Serialize(goal, goal.GetType(), new JsonSerializerOptions { WriteIndented = true });
            goalsJson.Add(jsonGoal);
        }

        // Create a wrapper object containing rank, score, and serialized goals
        var jsonObj = new
        {
            rank = _rank,
            score = _score,
            goals = goalsJson
        };

        // Serialize wrapper object to JSON text
        string json = JsonSerializer.Serialize(jsonObj, new JsonSerializerOptions { WriteIndented = true });

        // Write JSON text to specified file
        File.WriteAllText(file, json);

        Console.WriteLine("Goals successfully saved.");
    }

    // Loads goals, score, and rank from a JSON file
    private void LoadGoals()
    {
        // Reset rank, score, and clear current goals before loading
        _rank = 1;
        _score = 0;
        _goals.Clear();

        Console.Write("What is the filename for the goal file (.json)? ");
        string file = Console.ReadLine();

        // Ensure the specified file exists before continuing
        while (!File.Exists(file))
        {
            Console.Write("Invalid filename.\nType again (.json): ");
            file = Console.ReadLine();
        }

        // Read JSON content from file
        string json = File.ReadAllText(file);

        // Parse JSON document
        using (JsonDocument doc = JsonDocument.Parse(json))
        {
            var root = doc.RootElement;

            // Extract saved score and rank
            _score = root.GetProperty("score").GetInt32();
            _rank = root.GetProperty("rank").GetInt32();

            _goals = new List<Goal>();

            // Loop through each serialized goal string
            foreach (var item in root.GetProperty("goals").EnumerateArray())
            {
                string goalJson = item.GetString();

                // Parse the serialized goal JSON string to determine its type
                using (JsonDocument goalDoc = JsonDocument.Parse(goalJson))
                {
                    var goalRoot = goalDoc.RootElement;

                    string type = goalRoot.GetProperty("_type").GetString();
                    Goal goal = null;

                    // Deserialize JSON to the correct Goal subclass based on type
                    if (type == "SimpleGoal")
                    {
                        goal = JsonSerializer.Deserialize<SimpleGoal>(goalJson);
                    }
                    else if (type == "ChecklistGoal")
                    {
                        goal = JsonSerializer.Deserialize<ChecklistGoal>(goalJson);
                    }
                    else
                    {
                        goal = JsonSerializer.Deserialize<EternalGoal>(goalJson);
                    }

                    // Add deserialized goal to list
                    _goals.Add(goal);
                }
            }
        }
        Console.WriteLine("Goals successfully loaded.");
    }
}