using System;

public class Entry
{
    public string _date { get; set; }
    public string _promptText { get; set; }
    public string _entryText { get; set; }

    public Entry()
    {
    }

    public void Display()
    {
        Console.WriteLine($"\nDate: {_date}\nPrompt: {_promptText}\nResponse: {_entryText}");
    }
}