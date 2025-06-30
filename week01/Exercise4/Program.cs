using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Creates a list
        List<int> numbers = new List<int>();

        // Add items in the list
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        while (true)
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());
            if (number == 0)
            {
                break;
            }
            numbers.Add(number);
        }
        // Calculate and print the sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        // Calculate and print the average
        float average = (float)sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Find and print the maximum value
        int max = 0;
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The maximum value is: {max}");

        // Find and print the smallest positive value
        int min = max;
        foreach (int number in numbers)
        {
            if (number > 0 && number < min)
            {
                min = number;
            }
        }
        Console.WriteLine($"The smallest positive number is: {min}");

        // Sort and print the items of the list
        numbers.Sort();
        Console.WriteLine("The sorted list is: ");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}