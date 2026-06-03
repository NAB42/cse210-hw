/* 06.02.2026 Nathan Boulton
 * This acivity is literally just here to help the user breath better.
 * Quality breathing has been shown to increase cognitive function and lower stress.
 * People with OCD will be pissed unless they like to count to 5. He he 
 */

public class BreathingActivity : Activity
{
	public BreathingActivity() :
		base("Breathing Activity",
			 "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
	{
		
	}
	public void Display()
	{
		this.Begin();
		Thread.Sleep(2000);
		DateTime end = DateTime.Now.AddSeconds(this.GetDuration());
		int count = 0;
		// Repeats until the duration is up
		while(end > DateTime.Now)
		{
			Console.Clear();
			// Is it even?
			if(count % 2 == 0)
				Console.WriteLine("Breath In...");
			else 
				Console.WriteLine("Breath Out...");
			Thread.Sleep(700);
			// Adds pound signs to help you prepare
			for(int i = 0; i < 4; i++){
				Console.Write("# ");
				Thread.Sleep(700);
			}
			count++;
		}
		Console.WriteLine();
		this.End();
	}
}
