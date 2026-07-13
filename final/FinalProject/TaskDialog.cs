public class TaskDialog : Dialog 
{
	public TaskDialog(Task task)
	{
		Title = task.Name();
		View deets = task.BuildDetailView();
		if (deets != null)
		{
			deets.X = 0;
			deets.Y = 0;
			Add(deets);
		}

		TextView notes = new TextView
		{
			X = 0,
			Y = (deets != null) ? Pos.Bottom(deets) + 1 : 0,
			Width = Dim.Fill(),
			Height = Dim.Fill(1),
			Text = task.Notes()
		};
		Add(notes);

	}
}
