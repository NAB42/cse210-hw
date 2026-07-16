public class ChoreTask : Task
{
	private int _repeat;

	public ChoreTask(string name,string descr,int repeat) 
		: base(name,descr)
	{
		_repeat = repeat;
	}

	public int Rate()
	{
		return _repeat;
	}
	public void SetRate(int repeat)
	{
		_repeat = repeat;
	}
}
