using System.Collections.ObjectModel;
public class MainWindow : Window 
{
	private Group _group;
	private IApplication _app;

	private FrameView _toDo;
	private FrameView _inProgress;
	private FrameView _done;

	private ListView<Task> _doList;
	private ListView<Task> _progList;
	private ListView<Task> _doneList;

	public MainWindow(Group grp, IApplication app)
	{
		_group = grp;
		_app = app;
		Title = "Task Board (Ctrl+H for Help, Esc to Exit)";

		_toDo = new FrameView
		{
			Title = "To Do",
			X = 0,
			Y = 0,
			Width = Dim.Percent(33),
			Height = Dim.Fill(),
		};
		_inProgress = new FrameView
		{
			Title = "In Progress",
			X = Pos.Right(_toDo),
			Y = 0,
			Width = Dim.Percent(33),
			Height = Dim.Fill(),
		};

		_done = new FrameView
		{
			Title = "Done",
			X = Pos.Right(_inProgress),
			Y = 0,
			Width = Dim.Percent(33),
			Height = Dim.Fill(),
		};


		_doList = new ListView<Task>
		{
			X = 0,
			Y = 0,
			Width = Dim.Fill(),
			Height = Dim.Fill()
		};
		_doList.Accepting += (s, e) =>
		{
			if (_doList.Value is Task task)
			{
				TaskDialog dialog = new TaskDialog(task);
				_app.Run(dialog);
				dialog.Dispose();
			}
		};
		_progList = new ListView<Task>
		{
			X = 0,
			Y = 0,
			Width = Dim.Fill(),
			Height = Dim.Fill()
		};
		_doneList = new ListView<Task>
		{
			X = 0,
			Y = 0,
			Width = Dim.Fill(),
			Height = Dim.Fill()
		};
		_progList.Accepting += (s, e) =>
		{
			
			if (_progList.Value is Task task)
			{
				TaskDialog dialog = new TaskDialog(task);
				_app.Run(dialog);
				dialog.Dispose();
			}
		};
		_doneList.Accepting += (s, e) =>
		{
			if (_doneList.Value is Task task)
			{
				TaskDialog dialog = new TaskDialog(task);
				_app.Run(dialog);
				dialog.Dispose();
			}
		};


		KeyDown += (s, e) =>
		{
			ListView<Task>? active = 
				_doList.HasFocus ? _doList :
				_progList.HasFocus ? _progList :
				_doneList.HasFocus ? _doneList :
				null;
			if (active?.Value is not Task task )
				return;
			if (e == Key.T.WithCtrl)
			{
				task.SetState(0);
				task.SetCompletion(null);
			}
			else if (e == Key.P.WithCtrl)
			{
				task.SetState(1);
				task.SetCompletion(null);
			}
			else if (e == Key.D.WithCtrl)
			{
				task.SetState(2);
				task.SetCompletion(DateTime.Now);
			}
			else if (e == Key.R.WithCtrl)
			{
				_group.RemoveTask(task);
			}
			else return;
			e.Handled = true;
			LoadTasks();


		};

		KeyDown += (s, e) =>
		{
			if (e == Key.Tab)
			{
				if (_doList.HasFocus) _progList.SetFocus();
				else if (_progList.HasFocus) _doneList.SetFocus();
				else if (_doneList.HasFocus) _doList.SetFocus();
				e.Handled = true;
			}
			else if (e == Key.Tab.WithShift)
			{
				if (_doList.HasFocus) _doneList.SetFocus();
				else if (_progList.HasFocus) _doList.SetFocus();
				else if (_doneList.HasFocus) _progList.SetFocus();
				e.Handled = true;
			}
			else if (e == Key.H.WithCtrl)
			{
				HelpDialog helpWin = new HelpDialog();
				_app.Run(helpWin);
				helpWin.Dispose();
			}
			else if (e == Key.N.WithCtrl)
			{
				CreateDialog create = new CreateDialog(_app);
				_app.Run(create);
				Task newTask = create.Result();
				if (newTask != null)
				{
					_group.AddTask(newTask);
					LoadTasks();
				}
				create.Dispose();
			}
			
			else return;
			
			LoadTasks();
		};
		
		_doList.KeyBindings.Remove(Key.N.WithCtrl);
		_progList.KeyBindings.Remove(Key.N.WithCtrl);
		_doneList.KeyBindings.Remove(Key.N.WithCtrl);
		_doList.KeyBindings.Remove(Key.P.WithCtrl);
		_progList.KeyBindings.Remove(Key.P.WithCtrl);
		_doneList.KeyBindings.Remove(Key.P.WithCtrl);

		_toDo.Add(_doList);
		_inProgress.Add(_progList);
		_done.Add(_doneList);

		Add(_toDo,_inProgress,_done);
		LoadTasks();
	}

	private void LoadTasks()
	{
		_doList.SetSource(new ObservableCollection<Task>(
					_group.Tasks().Where(c => c.State() == 0)));
		_progList.SetSource(new ObservableCollection<Task>(
					_group.Tasks().Where(c => c.State() == 1)));
		_doneList.SetSource(new ObservableCollection<Task>(
					_group.Tasks().Where(c => c.State() == 2)));
	}
}
