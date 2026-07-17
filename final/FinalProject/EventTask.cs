public class EventTask : Task 
{
	private DateTime _dueDate;

	public EventTask(string name,string descr,DateTime due) : base(name,descr)
	{
		_dueDate = due;
	}

	public EventTask(string fileString) : base(fileString)
	{
		string[] parts = fileString.Split("|");
		_dueDate = DateTime.Parse(parts[5]);
	}

	public DateTime DueDate()
	{
		return _dueDate;
	}
	public void SetDueDate(DateTime due)
	{
		_dueDate = due;
	}
	public override View BuildDetailView() 
	{
		return new Label 
		{
			Text = $"Deadline: {_dueDate}\n{Descr()}\n{DateCompleted()}\nNotes"
		};
	}
	public override string ToFileString() 
	{
		return $"{base.ToFileString()}|{_dueDate.ToString()}";
	}
}
