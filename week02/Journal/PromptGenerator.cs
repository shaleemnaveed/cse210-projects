using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>();

    public PromptGenerator()
    {
    }

    public void LoadPrompts(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found!");
            return;
        }
        string[] lines = File.ReadAllLines(file);
        foreach (string line in lines)
        {
            _prompts.Add(line);
        }
    }
    private Random random = new Random();
    public string GetRandomPrompt()
    {
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}
