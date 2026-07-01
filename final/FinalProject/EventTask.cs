public class EventTask : Task 
{
	private DateTime _dueDate;

	public EventTask(string name,string descr,DateTime due) : base(name,descr)
	{
		_dueDate = due;
	}
}
