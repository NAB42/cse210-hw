/* 06.02.2026 Nathan Boulton
 *
 * This is the listing activity. The user receives a random prompt, and 
 * then is given their chosen duration of time to list out everything that 
 * comes to mind.
 */

public class ListingActivity : Activity 
{
	
	public ListingActivity() : 
		base("Listing Activity",
			 "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
	{

	}

	public void Display()
	{
		this.Begin();
		// Figuring out the duration of the thing
		DateTime end = DateTime.Now.AddSeconds(this.GetDuration());
		List<string> prompts = new List<string>()
		{
			"Who are people that you appreciate?",
			"What are personal strengths of yours?",
			"Who are people that you have helped this week?",
			"When have you felt the Holy Ghost this month?",
			"Who are some of your personal heroes?"
		};
		Console.WriteLine("Take a few seconds to think...");
		// Animation
		for(int i = 5; i > 0; i--)
		{
			Console.Write(i);
			Thread.Sleep(1000);
			Console.Write("\b \b");
		}
		Console.WriteLine("Ok List as many as you can!");
		List<string> answers = new List<string>();
		// List everything
		while(DateTime.Now < end)
		{
			Console.Write("> ");
			answers.Add(Console.ReadLine());
		}
		// Outputs number of answers given
		Console.WriteLine($"Nice! You wrote {answers.Count} answers!");
		this.End();
	}
}
