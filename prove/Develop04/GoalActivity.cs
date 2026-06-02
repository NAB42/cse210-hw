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
		Console.Write("Are you here to (1) set a goal or (2) follow up?\n> ");
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
			Console.WriteLine($"Take {this.GetDuration()/2} seconds to set a goal and make a plan to accomplish it.");
			this.Animate(this.GetDuration()/2);
			Console.WriteLine($"Now take {this.GetDuration()/2} seconds to record and schedule when you'll accomplish it!");
			this.Animate(this.GetDuration()/2);
			Console.WriteLine("Now make sure to follow up later!");
		}
		else
		{
			Console.WriteLine($"For {this.GetDuration} seconds, write down how it went, and what could be better next time.");
			this.Animate(this.GetDuration());
			Console.WriteLine("All done! Make sure to restart the cycle!");	
		}
		this.End();
	}
	private void Animate(int seconds)
	{
		for(int i = 0; i < seconds; i++)
		{
			Console.Write(i);
			Thread.Sleep(1000);
			if(i < 10)
				Console.Write("\b \b");
			else
				Console.Write("\b\b  \b\b");
		}
		Console.WriteLine();
	}
}
