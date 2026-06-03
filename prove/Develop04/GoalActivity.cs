/* 06.02.2026 Nathan Boulton
 * This is my unique activity, the Goal Activity.
 * Basically it is a tool to help the user be more mindful about what they 
 * want to accomplish and how, using the Goal-setting process from Preach My
 * Gospel. Depending on if they had made a goal already or were making one, the 
 * Display() method follows suit. Which option they pick is not logged.
 *
 */

public class GoalActivity : Activity
{
	public GoalActivity() 
		: base("Goal Activity","This activity helps you to use the goal-setting process to make effective goals.")
	{

	}
	public void Display()
	{
		this.Begin();
		Console.WriteLine(this.ToString());
		// Prompt to determine route
		Console.Write("Are you here to (1) set a goal or (2) follow up?\n> ");
		// For setting goals:
		if(int.Parse(Console.ReadLine()) == 1)
		{
			Console.WriteLine(
					"""
					The Goal-setting process involves 4 steps, as per Preach My Gospel:
					(1) Set Goals and Make Plans
					(2) Record and Schedule
					(3) Act on your plans 
					(4) Review and Follow up

					Today you are going to do the first 2 steps. 
					""");
			Thread.Sleep(3000);
			// Takes half of the time for each to getter done
			Console.WriteLine($"Take {this.GetDuration()/2} seconds to set a goal and make a plan to accomplish it.");
			this.Animate(this.GetDuration()/2);
			Console.WriteLine($"Now take {this.GetDuration()/2} seconds to record and schedule when you'll accomplish it!");
			this.Animate(this.GetDuration()/2);
			Console.WriteLine("Now make sure to follow up later!");
		} 
		// For following up:
		else
		{
			Console.WriteLine($"For {this.GetDuration} seconds, write down how it went, and what could be better next time.");
			this.Animate(this.GetDuration());
			Console.WriteLine("All done! Make sure to restart the cycle!");	
		}
		this.End();
	}

	// Private method, animates time.
	private void Animate(int seconds)
	{
		for(int i = 0; i < seconds; i++)
		{
			Console.Write(i);
			Thread.Sleep(1000);
			if(i < 10)
				Console.Write("\b \b");
			// Here to make sure double digits aren't ruining. Please don't input more than 99 seconds, I beg of you
			else
				Console.Write("\b\b  \b\b");
		}
		Console.WriteLine();
	}
}
