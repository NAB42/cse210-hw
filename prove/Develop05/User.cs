public class User
{
	private string _name;
	private Goal[] _goals = new Goal[8];
	public User(string name)
	{
		_name = name;
		ReadGoals();
		
	}
	public string Name()
	{
		return _name;
	}
	public void ReadGoals()
	{
		try{
			using (StreamReader reader = new StreamReader($"usr/{_name}"))
			{
				string[] goalsDone = reader.ReadLine().Split(" ");
				// Console.WriteLine($"{_name} {goalsDone.Length} {goalsDone[0]}"); // Debug
				SetGoals(goalsDone);
			}
		}
		catch (FileNotFoundException)
		{
			File.Create($"usr/{_name}").Dispose();
			SetGoals(new string[]{"false","false","false","0","0","0","0","0"});
		}
	}
	private void SetGoals(string[] goalsDone)
	{
		_goals[0] = new SingleGoal("Finish the Book of Mormon",200,bool.Parse(goalsDone[0]));
		_goals[1] = new SingleGoal("Read the whole standard works",1000,bool.Parse(goalsDone[1]));
		_goals[2] = new SingleGoal("Give a sacrament meeting talk",100,bool.Parse(goalsDone[2]));
		_goals[3] = new EternalGoal("Read a scripture chapter",10,int.Parse(goalsDone[3]));
		_goals[4] = new EternalGoal("Say daily prayers",5,int.Parse(goalsDone[4]));
		_goals[5] = new MultipleGoal("Attend the Temple",20,int.Parse(goalsDone[5]),10);
		_goals[6] = new MultipleGoal("Memorize a scripture",15,int.Parse(goalsDone[6]),20);
		_goals[7] = new EternalGoal("Complete a homework assignment",2,int.Parse(goalsDone[7]));

	}

	public void List()
	{
		Console.WriteLine("\nGOAL PROGRESS:\n");
		foreach(Goal goal in _goals)
		{
			Console.WriteLine(goal.ToString());
		}
		Console.WriteLine();
	}

	public void PrintPoints()
	{
		int points = 0;
		foreach(Goal goal in _goals)
		{
			points += goal.CalculatePoints();
		}
		Console.WriteLine($"Total points: {points}");
		Console.WriteLine("Rank is a WIP :)\n");
	}

	public void CompletelyDone()
	{
		Console.WriteLine("Select a number 1-8, or 0 to exit:");
		int count = 1;
		foreach(Goal goal in _goals)
		{
			Console.WriteLine($"{count}. {goal.Description()}");
			count++;
		}
		Console.Write("> ");
		int answer = int.Parse(Console.ReadLine());
		if (answer > 0)
			_goals[answer-1].Complete();
	}

	public void SaveGoals()
	{
		using(StreamWriter writer = new StreamWriter($"usr/{_name}"))
		{
			string completions = "";
			foreach(Goal goal in _goals)
			{
				completions += goal.Stat() + " ";
			}
			writer.WriteLine(completions.TrimEnd());
		}
	}
}
