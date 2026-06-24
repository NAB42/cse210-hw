using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Note: if your display does not support unicode, this could be a very sad game.");
		Board b = new Board();
		Thread.Sleep(3000);
		Console.CursorVisible = false;
		while(true)
		{
			Console.Clear();
			b.Display();
			Thread.Sleep(10);
		}
    }
}
