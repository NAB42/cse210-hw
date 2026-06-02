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
		while(end > DateTime.Now)
		{
			Console.Clear();
			if(count % 2 == 0)
				Console.WriteLine("Breath In...");
			else 
				Console.WriteLine("Breath Out...");
			Thread.Sleep(700);
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
