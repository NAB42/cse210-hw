using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a scripture:\n> ") ;
        Reference r = new Reference(Console.ReadLine());
        Console.WriteLine("Book is " +r.GetName());
        Console.WriteLine("Chatper is "+r.getChapter());
        Console.WriteLine("Verses are "+r.GetVerses());
    }
}