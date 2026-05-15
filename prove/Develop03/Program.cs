using System;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("> ");
        Scripture s = new Scripture(Console.ReadLine(),3);
        s.Write();
    }
}