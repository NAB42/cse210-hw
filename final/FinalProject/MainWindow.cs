public class MainWindow : Window 
{
	private Group _group;

	private FrameView _toDo;
	private FrameView _inProgress;
	private FrameView _done;

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
		Add(_toDo,_inProgress,_done);
	}
}
