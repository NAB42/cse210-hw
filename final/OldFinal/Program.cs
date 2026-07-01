using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Note: if your display does not support unicode, this could be a very sad game.");
		Location loc = new Location("B0");
		Board b = new Board(loc);
		Thread.Sleep(2000);
		Console.CursorVisible = false;
		while(true)
		{
			Console.Clear();
			b.Display();
			Console.WriteLine(loc.ToString());
			ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
			switch(keyInfo.Key)
			{
				case ConsoleKey.LeftArrow:
					loc.SetLocation(loc.GetLetter()-1,loc.GetNum());
					b.SetSelected(loc);
					break;
				case ConsoleKey.RightArrow:
					loc.SetLocation(loc.GetLetter()+1,loc.GetNum());
					b.SetSelected(loc);
					break;
				case ConsoleKey.UpArrow:
					loc.SetLocation(loc.GetLetter(),loc.GetNum()-1);
					b.SetSelected(loc);
					break;
				case ConsoleKey.DownArrow:
					loc.SetLocation(loc.GetLetter(),loc.GetNum()+1);
					b.SetSelected(loc);
					break;
				case ConsoleKey.R:
					loc.SetLocation(65,0);
					b.SetSelected(loc);
					break;
				case ConsoleKey.Spacebar:
					break;

			}
		}
    }
}
