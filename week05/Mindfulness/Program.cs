using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("\nMenu Options:\n 1. Start breathing activity\n 2. Start listing activity\n 3. Start reflecting activity\n 4. Quit\nSelect a choice from the menu: ");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 4)
            {
                Console.WriteLine("\nYou did well today.\n");
                break;
            }
            else if (choice == 1)
            {
                string description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on breathing.";
                BreathingActivity activity1 = new BreathingActivity("Breathing Activity", description);
                activity1.DisplayStartingMessage();
                activity1.Run();
                activity1.DisplayEndingMessage();
            }
            else if (choice == 2)
            {
                string description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
                ListingActivity activity2 = new ListingActivity("Listing Activity", description);
                activity2.DisplayStartingMessage();
                activity2.Run();
                activity2.DisplayEndingMessage();
            }
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