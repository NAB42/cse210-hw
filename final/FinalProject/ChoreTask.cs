public class ChoreTask : Task
{
	private int _repeat;

	public ChoreTask(string name,string descr,int repeat) 
		: base(name,descr)
	{
		_repeat = repeat;
	}
	public ChoreTask(string fileString) : base(fileString)
	{
		string[] parts = fileString.Split("|");
		_repeat = int.Parse(parts[5]);
	}

	public int Rate()
	{
		if ((DateTime.Now - GetCompletedDate())?.TotalDays > _repeat)
		{
			SetState(0);
		}
		return _repeat;
	}
	public void SetRate(int repeat)
	{
		_repeat = repeat;
	}
	public override View BuildDetailView() 
	{
		return new Label 
		{
			Text = $"{Descr()}\nRepeat every: {Rate()} days\n{DateCompleted()}\nNotes"
		};
	}
	public override string ToFileString() 
	{
		return $"{base.ToFileString()}|{_repeat}";
	}
}
