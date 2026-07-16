public class CheckTask : Task
{
	private List<Check> _checklist;

	public CheckTask(string name,string descr,List<Check> checklist)
		: base(name,descr)
	{
		_checklist = checklist;
	}

	public List<Check> GetList()
	{
		return _checklist;
	}
	public string List()
	{
		string output = "";
		foreach(Check c in _checklist)
		{
			output += c.ToString();
		}
		return output;
	}
	public override View BuildDetailView() 
	{
		string thing = "";
		foreach(Check item in _checklist)
		{
			thing += item.ToString() + "\n";
		}
		return new Label
		{
			Text = thing
		};
	}
}
