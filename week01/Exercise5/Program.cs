using System;

class Program
{
static void Main(string[] args)
{
    Console.WriteLine("Hello World! This is the Exercise5 Project.");
    // This program will ask the user for their name and favorite number,
    // then it will square the number and display the result.

    DisplayWelcome();
    string userName = PromptUserName();
    int favoriteNumber = PromptUserNumber();
    int squared = SquareNumber(favoriteNumber);
    DisplayResult(userName, squared);
}

static void DisplayResult(string name, int squaredNumber)
{
    Console.WriteLine($"{name}, the square of your number is {squaredNumber}.");
}

static void DisplayWelcome()
{
    Console.WriteLine("Welcome to the Program!");
}

static string PromptUserName()
{
    Console.Write("Please enter your name: ");
    return Console.ReadLine();
}

static int PromptUserNumber()
{
    Console.Write("Please enter your favorite number: ");
    string input = Console.ReadLine();
    int number = int.Parse(input);
    return number;
}

static int SquareNumber(int number)
{
    return number * number;
}
} 