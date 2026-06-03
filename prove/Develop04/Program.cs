/* 06.02.2026 Nathan Boulton
 * The purpose of this program is to help the user be more mindful.
 * There are 4 different activities, all of which are intended to
 * increase mindfulness. 
 * Each option picked instantiates a different object, and then runs 
 * through the Display() method for the determined duration. It then 
 * logs it in the file log.txt.
 */
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
		// For the logging
		string fileput;

		// This is the switch that determines which activity is going to be used. 
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
		
		// File Processing. This program logs each time the user runs it with a date, activity, and duration.
		string currentLog = "";
		// Reads the whole file into a string
		using(StreamReader str = new StreamReader("log.txt"))
		{
			currentLog += str.ReadLine();
		}
		// Then adds the new activity to the log.
		using (StreamWriter str = new StreamWriter("log.txt"))
		{
			str.WriteLine(currentLog + "\n" + fileput);
		}
    }
}
