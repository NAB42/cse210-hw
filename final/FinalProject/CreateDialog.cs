/** 2026 Nathan Boulton
 * This is the window for creating a new Task. It allows for selection of 
 * each type of task, with unique details.
 * pressing enter with empty fields may break the whole system. I didn't 
 * feel like taking time to idiot-proof my code, so GOOD LUCK!!
 */
public class CreateDialog : Dialog 
{
	// this enumeration makes the selector much easier to use because I 
	// can assign numbers to it. 
	public enum TaskType
	{
		Task,
		Chore,
		Event,
		Checklist
	}
	// Other fields
	private OptionSelector<TaskType> _typeSelector;
	private TextField _nameField;
	private TextField _descField;
	private View? _extraFields;

	private TextField? _deadline;
	private TextField? _interval;
	private TextField? _checklist;

	private Task _result;

	private IApplication _app;

	public CreateDialog(IApplication app)
	{
		_app = app;
		Title = "New Task";
		Width = Dim.Percent(70);
		Height = Dim.Percent(70);

		// This builds the window structure, what it looks like.
		Label name = new Label
		{
			Text = "Name: ", 
			X = 0,
			Y = 0
		};

		_nameField = new TextField 
		{
			X = Pos.Right(name) + 1,
			Y = 0,
			Width = Dim.Fill()
		};
		Label descr = new Label
		{
			Text = "Description: ",
			X = 0,
			Y = Pos.Bottom(name) + 1
		};
		_descField = new TextField 
		{
			X = Pos.Right(descr) + 1,
			Y = Pos.Bottom(_nameField) + 1,
			Width = Dim.Fill()
		};
		Label space = new Label
		{
			// instructions so the user doesn't crash their program
			Text = "Use arrow keys to navigate, press Space to select.",
			X = 0,
			Y = Pos.Bottom(descr) + 1,
		};
		_typeSelector = new OptionSelector<TaskType>
		{
			X = 0,
			Y = Pos.Bottom(space) + 1
		};
		// This is an action lambda to rebuild the window with the new fields, 
		// depending on what was selected. Claude!
		_typeSelector.ValueChanged += (s, e) => RebuildExtraFields();

		// put these in!
		Add(name, _nameField,descr, _descField, space, _typeSelector);
		RebuildExtraFields();

		// This is the create button. Not very necessary for the keyboard but great
		// for the mouse.
		Button create = new Button 
		{
			Text = "Create (Enter)",
			IsDefault = true 
		};
		create.Accepting += (s, e) => 
		{
			BuildResult();
			_app.RequestStop();
		};
		AddButton(create);

		_nameField.SetFocus();

	}
	// private method for changing the window.
	private void RebuildExtraFields()
	{
		// Used to check if there even is anything there
		if (_extraFields != null)
			Remove(_extraFields);
		_extraFields = new View 
		{
			X = 0,
			Y = Pos.Bottom(_typeSelector) + 1,
			Width = Dim.Fill(),
			Height = 3,
			CanFocus = true,
			TabStop = TabBehavior.TabStop
		};

		// a switch to determine what type of task fields are needed.
		// written by claude, heavily modified by me.
		switch(_typeSelector.Value)
		{
			case TaskType.Chore:
				Label interval = new Label 
				{
					Text = "Repeat every [] days:",
					X = 0,
					Y = 0
				};
				_interval = new TextField 
				{
					X = Pos.Right(interval) + 1,
					Y = 0,
					Width = 10
				};
				_extraFields.Add(interval,_interval);
				break;
			case TaskType.Event:
				Label deadline = new Label 
				{
					Text = "Deadline (yyyy-mm-dd): ",
					X = 0,
					Y = 0
				};
				_deadline = new TextField 
				{
					X = Pos.Right(deadline),
					Y = 0,
					Width = 15
				};
				_extraFields.Add(deadline,_deadline);
				break;
			case TaskType.Checklist:
				Label checklist = new Label 
				{
					Text = "Items (Separate with commas): ",
					X = 0,
					Y = 0,
				};
				_checklist = new TextField 
				{
					X = 0,
					Y = 1,
					Width = Dim.Fill()
				};
				_extraFields.Add(checklist,_checklist);
				break;
		}
		Add(_extraFields);
	}

	// another private method to make the task.
	private void BuildResult()
	{
		string name = _nameField.Text;
		string descr = _descField.Text;
		switch(_typeSelector.Value)
		{
			case TaskType.Chore:
				_result = new ChoreTask(name,descr,int.Parse(_interval.Text));
				break;
			case TaskType.Event:
				// don't type in the date wrong! I didn't idiot-proof this either.
				_result = new EventTask(name,descr,DateTime.Parse(_deadline.Text));
				break;
			case TaskType.Checklist:
				List<Check> list = new List<Check>();
				// the user separates them with commas, so this is handled.
				string[] checks = _checklist.Text.Split(',');
				foreach (string c in checks)
				{
					list.Add(new Check(c));
				}
				_result = new CheckTask(name,descr,list);
				break;
			default: 
				_result = new Task(name,descr);
				break;
		}
	}
	// Encapsulation!
	public Task Result()
	{
		return _result;
	}
}
