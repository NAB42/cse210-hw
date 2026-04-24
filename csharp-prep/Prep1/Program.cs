using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What's your first name? ");
        string first = Console.ReadLine();
        Console.WriteLine("What's your last name? ");
        string last = Console.ReadLine();
        Console.WriteLine($"Your name is {last}, {first} {last}.");
    }
}