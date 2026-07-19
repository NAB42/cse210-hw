/** 2026 Nathan Boulton
 * This is the parent class for the groups. The other 2 are currently 
 * non-functioning (nothing unique), so this is what's used. It handles 
 * the interactions of tasks, as well as the mass saving of said tasks.
 */

public class Group
{
	private List<Task> _tasks;
	
	public Group(List<Task> tasks)
	{
		_tasks = tasks;
	}
	public Group()
	{
		_tasks = new List<Task>();
	}
	public List<Task> Tasks()
	{
		return _tasks;
	}
	public  void AddTask(Task task){
		_tasks.Add(task);
	}
	public void SetList(List<Task> list)
	{
		_tasks = list;
	}
	public void RemoveTask(Task task)
	{
		_tasks.Remove(task);
	}
	// Save method. Pretty dang redundant, but I didn't know how I could 
	// do this better without naming the files 0 1 2 3.
	public void Save() 
	{
		string taskContents = "";
		string eventContents = "";
		string choreContents = "";
		string checkContents = "";
		foreach(Task task in _tasks)
		{
			string s = $"{task.ToFileString()}\n";

			if(task is EventTask)
				eventContents += s;
			else if(task is ChoreTask)
				choreContents = s;
			else if(task is CheckTask)
				checkContents = s;
			else
				taskContents += s;
		}
		// Here it writes the contents
		File.WriteAllText("tasks/Task",taskContents);
		File.WriteAllText("tasks/EventTask",eventContents);
		File.WriteAllText("tasks/ChoreTask",choreContents);
		File.WriteAllText("tasks/CheckTask",checkContents);
	}
	public Group Load()
	{
		/* Debug things. I didn't add checking for existing files, so if that doesn't exist it breaks
		File.WriteAllText("debug.log", $"Load() started. CWD: {Directory.GetCurrentDirectory()}\n");
		File.AppendAllText("debug.log", $"Looking for: {Path.GetFullPath("tasks/Task")}\n");
		File.AppendAllText("debug.log", $"tasks dir exists: {Directory.Exists("tasks")}\n");
		*/
		try{
			// Goes through and adds the tasks by each type.
			foreach(string line in File.ReadAllLines("tasks/Task"))
			{
				if (string.IsNullOrWhiteSpace(line)) continue;
				Task task = new Task(line);
				_tasks.Add(task);
			}
			foreach(string line in File.ReadAllLines("tasks/EventTask"))
			{
				if (string.IsNullOrWhiteSpace(line)) continue;
				EventTask task = new EventTask(line);
				_tasks.Add(task);
			}
			foreach(string line in File.ReadAllLines("tasks/ChoreTask"))
			{
				if (string.IsNullOrWhiteSpace(line)) continue;
				ChoreTask task = new ChoreTask(line);
				_tasks.Add(task);
			}
			foreach(string line in File.ReadAllLines("tasks/CheckTask"))
			{
				if (string.IsNullOrWhiteSpace(line)) continue;
				CheckTask task = new CheckTask(line);
				_tasks.Add(task);
			}
			File.AppendAllText("debug.log", $"Loaded {_tasks.Count} tasks successfully.\n");
		}
		catch(Exception e)
		{
			// if something breaks, this log will catch it (hopefully).
			File.WriteAllText("crash.log",e.ToString());
		}
		return new Group(_tasks);
	}
}
