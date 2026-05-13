using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop03 World!");
        Scripture s = new Scripture(new Reference("Malachi",4,4));
        Console.WriteLine(s.DisplayRef().ToString());
    }
}