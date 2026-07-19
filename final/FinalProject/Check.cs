/** 2026 Nathan Boulton
 * I didn't really need a class for this, but it felt a little better than 
 * having a List<string bool> type.
 * Anyways it's pretty straightforward. It's the checklist thing to determine 
 * if something is done or not. 
 */

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
