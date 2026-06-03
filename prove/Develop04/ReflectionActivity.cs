/* 06.02.2026 Nathan Boulton
 * This is the reflection activity. It asks meaningful questions to think about,
 * based ona  randomized prompt. 
 *
 */

public class ReflectionActivity : Activity 
{
	public ReflectionActivity() :
		base("Reflection Activity",
			 "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
	{

	}

	public void Display()
	{
		this.Begin();
		Thread.Sleep(2000);
		// One of 4 possible prompts. Uses the Random object.
		List<string> prompts = new List<string>()
		{
		 "Think of a time when you stood up for someone else.",
		 "Think of a time when you did something really difficult.",
		 "Think of a time when you helped someone in need.",
		 "Think of a time when you did something truly selfless."
		};
		int rand = new Random().Next(0,4);
		Console.WriteLine(prompts[rand]);
		Thread.Sleep(3000);
		// Once they press enter, the duration timer starts.
		Console.Write("You will now be shown 8 different questions to reflect upon. Press Enter to begin.");
		Console.ReadLine();
		DateTime start = DateTime.Now;
		DateTime end = start.AddSeconds(this.GetDuration());
		List<string> questions = new List<string>()
		{
		 "Why was this experience meaningful to you?",
		 "Have you ever done anything like this before?",
		 "How did you get started?",
		 "How did you feel when it was complete?",
		 "What made this time different than other times when you were not as successful?",
		 "What is your favorite thing about this experience?",
		 "What could you learn from this experience that applies to other situations?",
		 "What did you learn about yourself through this experience?",
		 "How can you keep this experience in mind in the future?"
		};
		// Asks the questions one at a time, clearing the console each time.
		foreach(string qs in questions)
		{
			Console.Clear();
			Console.WriteLine(prompts[rand]);
			Console.WriteLine(qs);
			Thread.Sleep(5000);
			if(end < DateTime.Now)
			{
				//Console.WriteLine(end);Console.WriteLine(DateTime.Now);
				break;
			}
		}
		this.End();
	}
}
