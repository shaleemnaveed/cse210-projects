// To exceed program requirements, I have:
// Implemented a Rank/Leveling system where players level up every 1000 points, adding gamification and motivating continued progress.
// Also replaced the required saving/loading method with json serialization/deserializtion.
 
using System;

// Main program entry point
class Program
{
    static void Main(string[] args)
    {
        // Create a new GoalManager instance and start the app
        GoalManager goal = new GoalManager();
        goal.Start();
    }
}