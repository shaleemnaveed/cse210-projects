using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            // Generate magic random number to guess
            Random random = new Random();
            int magicNumber = random.Next(1, 101);

            int count = 0;
            while (true)
            {
                // Get user's guess
                Console.Write("What is your guess? ");
                int userGuess = int.Parse(Console.ReadLine());

                count++;

                if (userGuess > magicNumber)
                {
                    Console.WriteLine("Lower.");
                }
                else if (userGuess < magicNumber)
                {
                    Console.WriteLine("Higher.");
                }
                else
                {
                    Console.WriteLine($"Congratulations! You guessed it correctly in {count} attempts.");
                    break;
                }
            }
            // Constructing game loop
            Console.Write("Do you wish to continue playing (y/n)? ");
            string userWish = Console.ReadLine().ToLower();

            if (userWish == "n")
            {
                Console.WriteLine("Thank you for playing.");
                break;
            }
        }
        
    }
}