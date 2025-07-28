using System;

class Program
{
    static void Main(string[] args)
    {
        // Base Class:
        Assignment assignment1 = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(assignment1.GetSummary());
        // Derived Class (Math):
        MathAssignment assignment2 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine($"{assignment2.GetSummary()}\n{assignment2.GetHomeworkList()}");
        // Derived Class (Writing):
        WrtingAssignment assignment3 = new WrtingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine($"{assignment3.GetSummary()}\n{assignment3.GetWritingInformation()}");
    }
}