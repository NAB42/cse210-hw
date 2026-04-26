using System;
/* This program is the beginnings of a number guessing game,
 * where the user picks a magic number and then "tries" to 
 * guess it. The idea for this eventually is that instead 
 * of the user creating the number, the program will us 
 * a Random object, but we aren't at that part of the 
 * assignment yet.
 */
class Program
{
    static void Main(string[] args)
    {
        // Establish variables
        int number = 6;         // The magic number
        int guess = 0;          // The guessed number
        bool guessed = false;   // The check for if the user guessed it correctly
        bool playAgain = true;  // The check if the game should continue

        // The first loop, which checks if the user wants to keep playing.
        do{
            // The program asks for a magic number for the guessing game.
            Console.Write("Enter a magic number: ");
            number = int.Parse(Console.ReadLine());
            // The second loop, which asks for a guess until the user gets it right.
            do{
                guessed = false;
                Console.Write("What's your guess? ");
                guess = int.Parse(Console.ReadLine());
                if(guess > number)
                {
                    Console.WriteLine("Lower");
                }
                else if(guess < number)
                {
                    Console.WriteLine("higher");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    guessed = true;
                }
            }while(!guessed);
            // Asks to play again (Although it displays 'N' as the option for no,
            // realistically you can type anything other than y.)
            Console.Write("Play again? (Y/N): ");
            playAgain = Console.ReadLine().Equals("Y".ToLower());
        }while(playAgain);
    }
}