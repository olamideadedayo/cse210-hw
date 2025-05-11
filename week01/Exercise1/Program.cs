using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise1 Project.");
    }
    static void GreetUser()
    {
        Console.WriteLine("Hello! Welcome to the program.");
        Console.WriteLine("what isyour first name?");
        string first = Console.ReadLine();
         Console.WriteLine("what isyour last name?");
         string last = Console.ReadLine();
          Console.WriteLine($"Your name is {last}, {first} {last}.");
    }
    
    
}
