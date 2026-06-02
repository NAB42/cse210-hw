using System;

class Program
{
    static void Main(string[] args)
    {
		Console.WriteLine(
				"""
				Welcome to the Mindfulness Program!!!!!
				Please pick a number:
				1. Breathing Activity
				2. Listing Activity
				3. Reflection Activity
				4. Goal Activity
				5. Quit
				""");
		Console.Write("> ");
		int answer = int.Parse(Console.ReadLine());
		string fileput;
		switch (answer)
		{
			case 1:
				BreathingActivity b = new BreathingActivity();
				b.Display();
				fileput = $"{DateTime.Now}: {b.GetName()}, {b.GetDuration()} seconds.";
				break;
			case 2:
				ListingActivity l = new ListingActivity();
				l.Display();
				fileput = $"{DateTime.Now}: {l.GetName()}, {l.GetDuration()} seconds.";
				break;
			case 3:
				ReflectionActivity r = new ReflectionActivity();
				r.Display();
				fileput = $"{DateTime.Now}: {r.GetName()}, {r.GetDuration()} seconds.";
				break;
			case 4:
				GoalActivity g = new GoalActivity();
				g.Display();
				fileput = $"{DateTime.Now}: {g.GetName()}, {g.GetDuration()} seconds.";
				break;
			case 5:
				return;
			default:
				return;

		}

		string currentLog = "";
		using(StreamReader str = new StreamReader("log.txt"))
		{
			currentLog += str.ReadLine();
		}
		using (StreamWriter str = new StreamWriter("log.txt"))
		{
			str.WriteLine(currentLog + "\n" + fileput);
		}
    }
}
