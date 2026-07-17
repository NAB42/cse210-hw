public class Check
{
	private bool _complete;
	private string _descr;

	public Check(string descr)
	{
		_descr = descr;
		_complete = false;
	}
	public Check(string descr,bool complete)
	{
		_descr = descr;
		_complete = complete;
	}
	public bool IsComplete()
	{
		return _complete;
	}
	public string Description()
	{
		return _descr;
	}
	public override string ToString()
	{
		string str = _complete ? "[X]" : "[ ]";
		return $"{str} {_descr}";
	}
}
