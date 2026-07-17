public class Task
{
	// Attributes 
	private string _name;
	private string _descr;
	private string _notes;
	private int _state;
	private DateTime? _dateCompleted;
	
	// Default constructor. I don't really see the point but why not.
	public Task()
	{
		_name = "Task";
		_descr = "Getter done";
		_notes = "";
		_state = 0;
	}
	public Task(string name,string descr)
	{
		_name = name;
		_descr = descr;
		_notes = "";
		_state = 0;
	}
	public Task(string fileString)
	{
		
		string[] parts = fileString.Split("|");
		_name = parts[0];
		_descr = parts[1];
		_notes = parts[3];
		ParseNotes();
		_state = int.Parse(parts[2]);
		_dateCompleted = string.IsNullOrEmpty(parts[4]) ? null : DateTime.Parse(parts[4]);
	}
	
	// Methods!
	public string Name()
	{
		return _name;
	}
	public string Descr()
	{
		return _descr;
	}
	public string Notes()
	{
		return _notes;
	}
	public int State()
	{
		return _state;
	}

	public void SetName(string name)
	{
		_name = name;
	}
	public void SetDescr(string descr)
	{
		_descr = descr;
	}
	public void SetNotes(string notes)
	{
		_notes = notes;
	}
	public void MoveUp()
	{
		if(_state < 3)
		{
			_state++;
		}
		else
			return;
		if(_state == 3)
		{
			_dateCompleted = DateTime.Now;
		}
	}
	public void SetState(int s)
	{
		_state = s;
	}
	public override string ToString()
	{
		return _name;
	}
	
	public virtual View BuildDetailView()
	{
		return null;
	}
	public void SetCompletion(DateTime? time)
	{
		_dateCompleted = time;
	}
	public string DateCompleted()
	{
		return _dateCompleted != null ? $"Date Completed: {_dateCompleted.ToString()}" : "";
	}
	public DateTime? GetCompletedDate()
	{
		return _dateCompleted;
	}
	private string FixNotes()
	{
		_notes.Replace("\n","\\n");
		return _notes;
	}
	private string ParseNotes()
	{
		_notes.Replace("\\n","\n");
		return _notes;
	}

	public virtual string ToFileString()
	{
		return $"{_name}|{_descr}|{_state}|{FixNotes()}|{_dateCompleted}";
	}
}
