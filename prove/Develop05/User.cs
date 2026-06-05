/* 06.04.2026 Nathan Boulton
 * This is the User class, which identifies the goal information, 
 * sets the username, and runs a lot of the commands in the CLI. 
 */

public class User
{
	/* Attributes */
	private string _name;
	private List<Goal> _goals;

	/* Constructor */
	public User(string name)
	{
		_name = name;
		ReadGoals();
		
	}

	/* Methods */
	public string Name()
	{
		return _name;
	}

	// This method loads the goals from the file into the User object. 
	public void ReadGoals()
	{
		try{
			using (StreamReader reader = new StreamReader($"usr/{_name}"))
			{
				// Splits the file up into the different groups for goal processing.
				string[] goalsDone = reader.ReadLine().Split(" ");
				_goals = new List<Goal>(goalsDone.Length);
				// Console.WriteLine($"{_name} {goalsDone.Length} {goalsDone[0]}"); // Debug
				SetGoals(goalsDone);
			}
		}
		catch (FileNotFoundException)
		{
			// If the user isn't found, A user record is created with a blank slate.
			File.Create($"usr/{_name}").Dispose();
			string[] s = new string[File.ReadAllLines("goals").Length];
			_goals = new List<Goal>(s.Length);
			for(int i = 0; i < s.Length; i++)
			{
				s[i] = "";
			}
			SetGoals(s);
		}
	}

	// Private method to set the goals according to the file specs.
	private void SetGoals(string[] goalsDone)
	{	
		// Loads all of the goals into memory	
		string[] lines = File.ReadAllLines("goals");

		// Checking if a user is missing some goals 
		if(lines.Length > goalsDone.Length)
		{
			List<string> temp = new List<string>(goalsDone);
			for(int i = 0; i < lines.Length-goalsDone.Length;i++)
			{
				temp.Add("0");
			}
			goalsDone = temp.ToArray();
		}

		// This is the loop that loads all of the goals into the user memory.
		for(int i = 0; i < lines.Length; i++)
		{
			// Console.WriteLine($"Len {_goals.Count}"); // debug
			string[] obj = lines[i].Split(",");
			if(goalsDone[i] == "")
				goalsDone[i] = "0";
			switch (obj[0])
			{

				// Single Goals 
				case "1":
					if(goalsDone[i] != "true" && goalsDone[i] != "false")
						goalsDone[i] = "false";
					_goals.Add(new SingleGoal(obj[1],int.Parse(obj[2]),bool.Parse(goalsDone[i])));
					break;
				// Checklist Goals 
				case "2":
					_goals.Add(new MultipleGoal(obj[1],int.Parse(obj[2]),int.Parse(goalsDone[i]),int.Parse(obj[3])));
					break;

				// Eternal Goals 
				case "3":
					_goals.Add(new EternalGoal(obj[1],int.Parse(obj[2]),int.Parse(goalsDone[i])));
					break;
				default:
					break;
			}
			// Console.WriteLine("This line got hit"); // debug
		}	
	}
	
	// For the touch command. Appends a goal to the list.
	public void AddGoal(Goal goal){
		_goals.Add(goal);
	}

	// This is the ls command. 
	public void List()
	{
		Console.WriteLine("\nGOAL PROGRESS:\n");
		foreach(Goal goal in _goals)
		{
			Console.WriteLine(goal.ToString());
		}
		Console.WriteLine();
	}

	// pwd
	public void PrintPoints()
	{
		int points = TotalPoints();
		Console.WriteLine($"Total points: {points}");
		// Console.WriteLine("Rank is a WIP :)\n");
	}

	// Used to return rather than print. Used in pwd and cat.
	public int TotalPoints()
	{
		int points = 0;
		foreach(Goal goal in _goals)
		{
			points += goal.CalculatePoints();
		}
		return points;

	}

	// cd
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

	// Overwrites the old goal information with the updated goal information.
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
