using System;
using System.Text.Json;

class Program
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
            int index = int.Parse(Console.ReadLine());
            Console.Write("Enter a scripture reference:\n❯ ");
            Scripture scrip = new Scripture(Console.ReadLine(),index);
            Console.Clear();
            while(true){
                scrip.Write();
                Console.Write("\nq to quit, enter to hide more:\n❯ ");
                string answer = Console.ReadLine();
                if(answer == "q" || answer == "quit")
                    break;
                scrip.HideSome();
                Console.Clear();
            }
            Console.Write("Press q to quit, or enter to go back to start:\n❯ ");
            if(Console.ReadLine()=="q")
                break;
            Console.Clear();
        }
    }
}