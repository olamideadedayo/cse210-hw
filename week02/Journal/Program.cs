using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public DateTime Date { get; set; }
    public string Content { get; set; }

    public override string ToString()
    {
        return $"{Date.ToString("yyyy-MM-dd HH:mm")} - {Content}";
    }
}

class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();

    public void AddEntry(string content)
    {
        entries.Add(new JournalEntry { Date = DateTime.Now, Content = content });
        Console.WriteLine("Entry added.");
    }

    public void ViewEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
            return;
        }

        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Content}");
            }
        }
        Console.WriteLine("Journal saved.");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        entries.Clear();
        foreach (var line in File.ReadAllLines(filename))
        {
            var parts = line.Split('|');
            if (parts.Length == 2 && DateTime.TryParse(parts[0], out DateTime date))
            {
                entries.Add(new JournalEntry { Date = date, Content = parts[1] });
            }
        }
        Console.WriteLine("Journal loaded.");
    }
}

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        string fileName = "journal.txt";
        bool running = true;
        Console.WriteLine("Welcome to the Journal Application!");
        Console.WriteLine("You can add, view, save, and load your journal entries.");
        Console.WriteLine("Type 'exit' to quit the application at any time.");
        // Console.WriteLine("write"); // Removed invalid line


        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Add Entry");
            Console.WriteLine("2. View Entries");
            Console.WriteLine("3. Save to File");
            Console.WriteLine("4. Load from File");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Enter your journal entry: ");
                    string content = Console.ReadLine();
                    journal.AddEntry(content);
                    break;
                case "2":
                    journal.ViewEntries();
                    break;
                case "3":
                    journal.SaveToFile(fileName);
                    break;
                case "4":
                    journal.LoadFromFile(fileName);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }
}

// This code implements a simple journal application that allows users to add, view, save, and load journal entries.