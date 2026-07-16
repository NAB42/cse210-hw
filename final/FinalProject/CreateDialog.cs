public class CreateDialog : Dialog 
{
	public enum TaskType
	{
		Task,
		Chore,
		Event,
		Checklist
	}
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
		_typeSelector = new OptionSelector<TaskType>
		{
			X = 0,
			Y = Pos.Bottom(descr) + 1
		};

		_typeSelector.ValueChanged += (s, e) => RebuildExtraFields();

		Add(name, _nameField,descr, _descField, _typeSelector);
		RebuildExtraFields();

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
	private void RebuildExtraFields()
	{
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
				_result = new EventTask(name,descr,DateTime.Parse(_deadline.Text));
				break;
			case TaskType.Checklist:
				List<Check> list = new List<Check>();
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

	public Task Result()
	{
		return _result;
	}
}
