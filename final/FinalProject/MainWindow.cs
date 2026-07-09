using System.Collections.ObjectModel;
public class MainWindow : Window 
{
	private Group _group;

	private FrameView _toDo;
	private FrameView _inProgress;
	private FrameView _done;

	private ListView _doList;
	private ListView _progList;
	private ListView _doneList;

	public MainWindow(Group grp)
	{
		_group = grp;
		Title = "Kanban Board (Esc)";

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

		_doList = new ListView 
		{
			X = 0,
			Y = 0,
			Width = Dim.Fill(),
			Height = Dim.Fill()
		};
		_progList = new ListView 
		{
			X = 0,
			Y = 0,
			Width = Dim.Fill(),
			Height = Dim.Fill()
		};
		_doneList = new ListView 
		{
			X = 0,
			Y = 0,
			Width = Dim.Fill(),
			Height = Dim.Fill()
		};
		
		_toDo.Add(_doList);
		_inProgress.Add(_progList);
		_done.Add(_doneList);

		Add(_toDo,_inProgress,_done);
		LoadTasks();
	}

	private void LoadTasks()
	{
		_doList.SetSource<Task>(new ObservableCollection<Task>(_group.Tasks().Where(c => c.State() == 0)));
		_progList.SetSource<Task>(new ObservableCollection<Task>(_group.Tasks().Where(c => c.State() == 1)));
		_doneList.SetSource<Task>(new ObservableCollection<Task>(_group.Tasks().Where(c => c.State() == 2)));
	}
}
