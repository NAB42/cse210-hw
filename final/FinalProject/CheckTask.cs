public class CheckTask : Task
{
	private List<Check> _checklist;

	public CheckTask(string name,string descr,List<Check> checklist)
		: base(name,descr)
	{
		_checklist = checklist;
	}
	public CheckTask(string fileString) : base(fileString)
	{
		string[] parts = fileString.Split("|");
		string[] checks = parts[5].Split(";");
		_checklist = new List<Check>();
		File.WriteAllLines("check.log",checks);
		foreach(string s in checks)
		{
			if (string.IsNullOrWhiteSpace(s)) continue;
			string[] bits = s.Split(",");
			File.AppendAllLines("check.log",bits);
			_checklist.Add(new Check(bits[0],bool.Parse(bits[1])));
		}
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
			Text = Descr() + "\n" + thing + $"\n{DateCompleted()}\nNotes"
		};
	}
	public override string ToFileString() 
	{
		string parsedCheck = "";
		foreach(Check c in _checklist)
		{
			parsedCheck += $"{c.Description()},{c.IsComplete()};";
		}
		return base.ToFileString() + $"|{parsedCheck}";
	}
}
