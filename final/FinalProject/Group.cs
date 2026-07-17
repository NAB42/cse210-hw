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
		File.WriteAllText("tasks/Task",taskContents);
		File.WriteAllText("tasks/EventTask",eventContents);
		File.WriteAllText("tasks/ChoreTask",choreContents);
		File.WriteAllText("tasks/CheckTask",checkContents);
	}
	public Group Load()
	{
		File.WriteAllText("debug.log", $"Load() started. CWD: {Directory.GetCurrentDirectory()}\n");
    File.AppendAllText("debug.log", $"Looking for: {Path.GetFullPath("tasks/Task")}\n");
    File.AppendAllText("debug.log", $"tasks dir exists: {Directory.Exists("tasks")}\n");
		try{
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
		}catch(Exception e){File.WriteAllText("crash.log",e.ToString());}
		return new Group(_tasks);
	}
}
