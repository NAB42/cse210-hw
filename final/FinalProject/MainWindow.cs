/** 2026 Nathan Boulton
 * While Program.cs is technically the main file, this one is where a lot of 
 * the magic happens. 
 * This is the main window display. It draws all of the columns with the tasks,
 * handles keybinds, and loads the tasks into place with the given group. It 
 * inherits from the Window class in the Terminal.Gui library. 
 * Honestly there's a lot of redundancy in this program, and I had I given myself 
 * more time I would have made it a little better. 
 */

using System.Collections.ObjectModel;
public class MainWindow : Window 
{
	// Fields (holy cow there's a lot)
	private Group _group;
	private IApplication _app;

	private FrameView _toDo;
	private FrameView _inProgress;
	private FrameView _done;

	private ListView<Task> _doList;
	private ListView<Task> _progList;
	private ListView<Task> _doneList;

	private Action _onSave;

	public MainWindow(Group grp, IApplication app, Action onSave)
	{
		// initialize the parameters
		_group = grp;
		_app = app;
		_onSave = onSave;
		Title = "Task Board (Ctrl+H for Help, Esc to Exit)";
		
		// Here are the 3 columns
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

		// here are the lists of tasks that are added to each column, with 
		// support for opening the task dialog window. 
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

		// keybinds. Claude helped me a lot with this, that is where I learned 
		// (s,e) from with this Lambda. I'm not the biggest fan but it works. 
		KeyDown += (s, e) =>
		{
			// Check what's active. Mega ternary operater, know you love them!
			ListView<Task>? active = 
				_doList.HasFocus ? _doList :
				_progList.HasFocus ? _progList :
				_doneList.HasFocus ? _doneList :
				null;
			// is this a task? If not blow it up!
			if (active?.Value is not Task task )
				return;
			// Move to To Do
			if (e == Key.T.WithCtrl)
			{
				task.SetState(0);
				task.SetCompletion(null);
			}
			// Move to in progress
			else if (e == Key.P.WithCtrl)
			{
				task.SetState(1);
				task.SetCompletion(null);
			}
			// Move to done
			else if (e == Key.D.WithCtrl)
			{
				// When a task is moved into the Done column, a date 
				// of completion is added. 
				task.SetState(2);
				task.SetCompletion(DateTime.Now);
			}
			// Remove a task (dangerous)
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
			// Move focus
			if (e == Key.Tab)
			{
				if (_doList.HasFocus) _progList.SetFocus();
				else if (_progList.HasFocus) _doneList.SetFocus();
				else if (_doneList.HasFocus) _doList.SetFocus();
				e.Handled = true;
			}
			// Move focus backwards
			else if (e == Key.Tab.WithShift)
			{
				if (_doList.HasFocus) _doneList.SetFocus();
				else if (_progList.HasFocus) _doList.SetFocus();
				else if (_doneList.HasFocus) _progList.SetFocus();
				e.Handled = true;
			}
			// Access the help page
			else if (e == Key.H.WithCtrl)
			{
				HelpDialog helpWin = new HelpDialog();
				_app.Run(helpWin);
				helpWin.Dispose();
			}
			// this opens up the New Task window.
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
			// save the tasks
			else if (e == Key.S.WithCtrl)
			{
				_onSave();
				e.Handled = true;
			}
			else return;
			
			LoadTasks();
		};
		
		// Remove some Emacs bindings that are default to keep it all working. 
		_doList.KeyBindings.Remove(Key.N.WithCtrl);
		_progList.KeyBindings.Remove(Key.N.WithCtrl);
		_doneList.KeyBindings.Remove(Key.N.WithCtrl);
		_doList.KeyBindings.Remove(Key.P.WithCtrl);
		_progList.KeyBindings.Remove(Key.P.WithCtrl);
		_doneList.KeyBindings.Remove(Key.P.WithCtrl);

		// Add lists to the columns
		_toDo.Add(_doList);
		_inProgress.Add(_progList);
		_done.Add(_doneList);

		// Add columns to the window
		Add(_toDo,_inProgress,_done);
		LoadTasks();
	}

	// This method was written by Claude and heavily modified by me. 
	// It basically just reloads the tasks from memory into the display.
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
