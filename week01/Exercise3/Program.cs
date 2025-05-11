using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");
        
        
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 10);
   
        int guess = 1;  
        // The loop continues until the user guesses the magic number
        while (guess != magicNumber) 
        {
            
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }

    }

    }  
}