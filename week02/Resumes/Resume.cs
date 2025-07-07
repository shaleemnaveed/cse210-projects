using System;

// Keeps track of the person's name and a list of their jobs.
public class Resume
{
    // Attributes
    public string _name = "";
    public List<Job> _jobs = new List<Job>();

    public Resume()
    {
    }

    // Behaviors
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}