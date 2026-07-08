public abstract class Group
{
	private List<Task> _tasks;

	public List<Task> Tasks()
	{
		return _tasks;
	}
	public  void AddTask(Task task){
		_tasks.Add(task);
	}
}
