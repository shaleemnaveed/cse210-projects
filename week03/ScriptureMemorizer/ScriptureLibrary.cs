using System;
using System.IO;
using System.Collections.Generic;

public class ScriptureLibrary
{
    // Attributes:
    private List<Scripture> _scriptures = new List<Scripture> ();

    // Constructors:
    public ScriptureLibrary(string file)
    {
        LoadScriptures(file);
    }

    // Methods:
    private void LoadScriptures(string file)
    {
        if(!File.Exists(file))
        {
            Console.WriteLine("File not found!");
            return;
        }

        string[] lines = File.ReadAllLines(file);
        for(int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(",");

            string[] referencePart = parts[0].Split(' ');
            string versePart = parts[1].Trim('"');

            string book = referencePart[0];
            int chapter = int.Parse(referencePart[1]);
            int verse = int.Parse(referencePart[2]);

            Reference reference;

            if(referencePart.Length == 3)
            {
                reference = new Reference(book, chapter, verse);
            }
            else
            {
                int endVerse = int.Parse(referencePart[3]);
                reference = new Reference(book, chapter, verse, endVerse);
            }
            _scriptures.Add(new Scripture(reference, versePart));
        }
    }

    private Random random = new Random();
    public Scripture GetRandomScripture()
    {
        int index = random.Next(_scriptures.Count);
        return _scriptures[index];
    }
}