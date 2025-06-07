using System;

class Program
{
    static void Main(string[] args)
    {
        // Example scripture
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string scriptureText = "Trust in the Lord with all thine heart and lean not unto thine own understanding.";
        Scripture scripture = new Scripture(reference, scriptureText);

        while (true)
        {
            Console.Clear();
            scripture.Display();

            if (scripture.AllWordsHidden())
                break;

            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3); // Hide 3 random words per round
        }
    }
}

public class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int EndVerse { get; }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        if (StartVerse == EndVerse)
            return $"{Book} {Chapter}:{StartVerse}";
        else
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
    }
}

// Scripture class definition
public class Scripture
{
    private Reference _reference;
    private List<string> _words;
    private List<bool> _hidden;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').ToList();
        _hidden = new List<bool>(new bool[_words.Count]);
    }

    public void Display()
    {
        Console.WriteLine(_reference.ToString());
        for (int i = 0; i < _words.Count; i++)
        {
            if (_hidden[i])
                Console.Write("____ ");
            else
                Console.Write(_words[i] + " ");
        }
        Console.WriteLine();
    }

    public void HideRandomWords(int count)
    {
        Random rand = new Random();
        var indices = Enumerable.Range(0, _words.Count)
            .Where(i => !_hidden[i])
            .OrderBy(x => rand.Next())
            .Take(count)
            .ToList();

        foreach (var i in indices)
            _hidden[i] = true;
    }

    public bool AllWordsHidden()
    {
        return _hidden.All(h => h);
    }
}
