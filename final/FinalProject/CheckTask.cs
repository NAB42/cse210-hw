/** 2026 Nathan Boulton
 * This is the checklist task. It has a list of things to do inside of it,
 * that can be checked off for completion (Kind of. It's still a WIP there). 
 * Inherits the Task class.
 *
 */
public class CheckTask : Task
{
	// Only 1 new field. Cure lil checklist.
	private List<Check> _checklist;

	public CheckTask(string name,string descr,List<Check> checklist)
		: base(name,descr)
	{
		_checklist = checklist;
	}
	public CheckTask(string fileString) : base(fileString)
	{
		// Ok, this is kind of a mess, but it works! 3 split string[]s!
		string[] parts = fileString.Split("|");
		string[] checks = parts[5].Split(";");
		_checklist = new List<Check>();
		//File.WriteAllLines("check.log",checks); (debug)
		foreach(string s in checks)
		{
			// This is a check to make sure there isn't a trailing split token.
			if (string.IsNullOrWhiteSpace(s)) continue;
			string[] bits = s.Split(",");
			File.AppendAllLines("check.log",bits);
			// Finally, we're there! Hope the user doesn't add semicolons to the mix!
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
	// Creates the parsed checklist thingymabob
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
