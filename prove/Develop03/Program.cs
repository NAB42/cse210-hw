/* Scripture Memorizer Project
 * 2026.05.15 Nathan Boulton
 * 
 * This project is designed to help avid scripture scholars to better memorize verses.
 * It starts with an option to pick from part of the standard works, then asks for a reference.
 * It then displays the verses, and slowly starts removing words and leaving blank spaces
 * in their places.
 * At the end, it tests the user for their memory. If they fail, it gives them the option to 
 * retry. If they succeed, it goes back to the main menu. 
 */
using System;
using System.Text.Json;

public class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Scripture Memorizer!");
        while(true){
            Console.Write(
                """
                Pick a book from the standard works (1-5):
                1. Old Testament
                2. New Testament
                3. Book of Mormon
                4. Doctrine and Covenants
                5. Pearl of Great Price
                ❯ 
                """
            );
            // Gets the index for which book to use
            int index = int.Parse(Console.ReadLine());
            Console.Write("Enter a scripture reference:\n❯ ");
            Scripture scrip = new Scripture(Console.ReadLine(),index);
            Console.Clear();

            // This is the loop for memorizing the verses.
            while(true){
                scrip.Write();
                Console.Write("\nq to quit, enter to hide more:\n❯ ");
                string answer = Console.ReadLine();
                if(answer == "q")
                    break;
                // Hides some of the words, and checks if they're all gone.
                bool allGone = scrip.HideSome();
                if (allGone)
                {
                    Console.Clear();
                    Console.WriteLine("All of the words are gone! Time for the test!");
                    // This is the test. It goes verse by verse and the user has to get it right.
                    bool passed = scrip.Test();
                    if (passed)
                    {
                        Console.WriteLine("You did it! Press enter to continue.");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.Write("You failed. Would you like to retry (y/n)?\n❯ ");
                        string check = Console.ReadLine();
                        if (check == "y")
                        {
                            scrip.Reset();
                            Console.Clear();
                            continue;
                        }
                        else 
                            break;
                    }
                }
                Console.Clear();
            }
            Console.Write("Press q to quit, or enter to go back to start:\n❯ ");
            if(Console.ReadLine()=="q")
                break;
            Console.Clear();
        }
    }
}