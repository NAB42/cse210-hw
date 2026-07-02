public class ChoreTask : Task
{
	private string _repeat;

	public ChoreTask(string name,string descr,string repeat) 
		: base(name,descr)
	{
		_repeat = repeat;
	}

	public string Rate()
	{
		return _repeat;
	}
	public void SetRate(string repeat)
	{
		_repeat = repeat;
	}
}
