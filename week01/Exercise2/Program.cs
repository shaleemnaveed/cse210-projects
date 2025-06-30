using System;

class Program
{
    static void Main(string[] args)
    {
        // Gets user's grade percentage
        Console.Write("What is your grade percentage? ");
        float percentage = float.Parse(Console.ReadLine());

        // Calculate grade
        string letter;
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Assign signs
        string sign = "";
        if (percentage % 10 >= 7)
        {
            if (!(letter == "A" || letter == "F"))
            {
                sign = "+";
            }
        }
        else if (percentage % 10 < 3)
        {
            if (!(letter == "F"))
            {
                sign = "-";
            }
        }

        // Print user's grade
        Console.WriteLine($"You scored a grade of {letter}{sign}");

        // Determine whether user passed the class or not
        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class.");
        }
        else
        {
            Console.WriteLine("Unfortunately, you failed to pass the class. Better luck next time!");
        }
    }
}