public class User
{
	private string _name;
	private Goal[] _goals = new Goal[8];
	public User(string name)
	{
		_name = name;
		try{
			using (StreamReader reader = new StreamReader($"usr/{_name}.gq"))
			{
				string[] goalsDone = reader.ReadLine().Split(" ");
				Console.WriteLine($"{_name} {goalsDone.Length} {goalsDone[0]}");
				_goals[0] = new SingleGoal("Finish the Book of Mormon",200,bool.Parse(goalsDone[0]));
				_goals[1] = new SingleGoal("Read the whole standard works",1000,bool.Parse(goalsDone[1]));
				_goals[2] = new SingleGoal("Give a sacrament meeting talk",100,bool.Parse(goalsDone[2]));
				_goals[3] = new EternalGoal("Read a scripture chapter",10,int.Parse(goalsDone[3]));
				_goals[4] = new EternalGoal("Say daily prayers",5,int.Parse(goalsDone[4]));
				_goals[5] = new MultipleGoal("Attend the Temple",20,int.Parse(goalsDone[5]),10);
				_goals[6] = new MultipleGoal("Memorize a scripture",15,int.Parse(goalsDone[6]),20);
				_goals[7] = new EternalGoal("Complete a homework assignment",2,int.Parse(goalsDone[7]));
			}
		}
		catch (FileNotFoundException)
		{
			File.Create($"/usr/{_name}.gq").Dispose();
		}
	}

	public void List()
	{
		Console.WriteLine("GOAL PROGRESS:\n");
		foreach(Goal goal in _goals)
		{
			Console.WriteLine(goal.ToString());
		}
		Console.WriteLine();
	}

	public void CompletelyDone()
	{
		Console.WriteLine("TODO");
	}
}
