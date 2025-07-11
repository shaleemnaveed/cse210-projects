using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public Journal()
    {
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("History: None");
        }
        else
        {
            Console.WriteLine("History:");
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }
    }

    public void SaveToFile(string file)
    {
        // using (StreamWriter outputFile = new StreamWriter(file))
        // {
        //     foreach (Entry entry in _entries)
        //     {
        //         outputFile.WriteLine($"{entry._date}--{entry._promptText}--{entry._entryText}");
        //     }
        // }
        string json = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(file, json);
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found!");
            return;
        }
        // string[] lines = File.ReadAllLines(file);
        // _entries.Clear();
        // foreach (string line in lines)
        // {
        //     string[] parts = line.Split("--");
        //     Entry entry = new Entry();
        //     entry._date = parts[0];
        //     entry._promptText = parts[1];
        //     entry._entryText = parts[2];
        //     AddEntry(entry);
        // }
        string json = File.ReadAllText(file);
        _entries = JsonSerializer.Deserialize<List<Entry>>(json);
    }
}