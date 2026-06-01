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
				4. Quit
				""");
		Console.Write("> ");
		int answer = int.Parse(Console.ReadLine());

		switch (answer)
		{
			case 1:
				new BreathingActivity().Display();
				break;
			case 2:
				new ListingActivity().Display();
				break;
			case 3:
				ReflectionActivity r = new ReflectionActivity();
				r.Display();
				break;
			case 4:
				return;
			default:
				return;

		}
    }
}
