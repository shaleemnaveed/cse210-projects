// To exceed requirements, I created a new class: PromptManager to manage the list of prompts and questions.
// This class has one method that provides unique prompts and questions.
// Furthermore, all three instances of this class are marked static for same cause.

using System;

// Entry point of the program
class Program
{
    static void Main(string[] args)
    {
        // Infinite loop for displaying menu until user chooses to quit
        while (true)
        {
            Console.Write("\nMenu Options:\n 1. Start breathing activity\n 2. Start listing activity\n 3. Start reflecting activity\n 4. Quit\nSelect a choice from the menu: ");
            int choice = int.Parse(Console.ReadLine());

            // Exit option
            if (choice == 4)
            {
                Console.WriteLine("\nYou did well today.\n");
                break;
            }
            // Breathing Activity
            else if (choice == 1)
            {
                string description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on breathing.";
                BreathingActivity activity1 = new BreathingActivity("Breathing Activity", description);
                activity1.DisplayStartingMessage();
                activity1.Run();
                activity1.DisplayEndingMessage();
            }
            // Listing Activity
            else if (choice == 2)
            {
                string description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
                ListingActivity activity2 = new ListingActivity("Listing Activity", description);
                activity2.DisplayStartingMessage();
                activity2.Run();
                activity2.DisplayEndingMessage();
            }
            // Reflecting Activity
            else if (choice == 3)
            {
                string description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize\nthe power you have and how you can use it in other aspects of your life.";
                ReflectingActivity activity3 = new ReflectingActivity("Reflection Activity", description);
                activity3.DisplayStartingMessage();
                activity3.Run();
                activity3.DisplayEndingMessage();
            }
        }
    }
}
