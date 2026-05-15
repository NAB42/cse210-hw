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
            Console.Write("❯ ");
            Scripture s = new Scripture(Console.ReadLine(),index);
            s.Write();
            Console.ReadLine();
            Console.Clear();
        }
    }
}