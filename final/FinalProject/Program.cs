using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Note: if your display does not support unicode, this could be a very sad game.");
		Board b = new Board();
		b.Display();
    }
}
