// To exceed requirements, I have the program to load scriptures from a csv file.
// For this, I have created a new class ScriptureLibrary.

using System;

class Program
{
    static void Main(string[] args)
    {

        ScriptureLibrary library = new ScriptureLibrary("scriptures.csv");
        Scripture scripture = library.GetRandomScripture();

        while (true)
        {
            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine("\nPress enter to continue or type 'quit' to finish");
            string response = Console.ReadLine().ToLower();

            if (response == "quit")
            {
                break;
            }
            else if (scripture.IsCompletelyHidden())
            {
                break;
            }
            else
            {
                scripture.HideRandomWords(3);
                Console.Clear();
            }
        }
    }
}