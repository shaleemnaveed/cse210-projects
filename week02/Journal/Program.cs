// To exceed requirements, I have loaded a text file of prompts to generate a random prompt from.
// To exceed requirements, I have used json to save into and load from a file.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\nWelcome to the Journal Program.");

        Journal journal = new Journal();

        PromptGenerator prompts = new PromptGenerator();
        prompts.LoadPrompts("prompts.txt");
    
        while (true)
        {
            Console.WriteLine("\nPlease select one of the following choices:\n1. Write\n2. Display\n3. Save\n4. Load\n5. Quit");
            Console.Write("What would you like to do? ");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine();
            if (choice < 1 || choice > 5)
            {
                Console.WriteLine("Invalid Choice.");
                continue;
            }
            else if (choice == 5)
            {
                Console.WriteLine("Quitting Journal\n----------------\nHave a nice day!\n");
                break;
            }
            else if (choice == 1)
            {
                string prompt = prompts.GetRandomPrompt();

                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                Entry entry = new Entry();
                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = prompt;
                entry._entryText = response;

                journal.AddEntry(entry);
            }
            else if (choice == 2)
            {
                journal.DisplayAll();
            }
            else if (choice == 3)
            {
                Console.WriteLine("What is the filename (Use extension .json)?");
                Console.Write("> ");
                string file = Console.ReadLine();
                journal.SaveToFile(file);
            }
            else if (choice == 4)
            {
                Console.WriteLine("What is the filename (Use extension .json)?");
                Console.Write("> ");
                string file = Console.ReadLine();
                journal.LoadFromFile(file);
            }
        }
    }
}