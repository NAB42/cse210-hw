/** 2026 Nathan Boulton
 * This is the window that shows the information for the tasks.
 * It shows different info depending on which task type it is,
 * and allows for notes to be taken by the user.
 * Written by Claude initially, but it was basically all changed 
 * by me to what I wanted.
 */

public class TaskDialog : Dialog 
{
	public TaskDialog(Task task)
	{
		Title = $"{task.Name()} (Esc)";
		Width = Dim.Percent(50);
		Height = Dim.Percent(50);
		// builds the tasktype-specific view
		View deets = task.BuildDetailView();
		// deets means details, if you couldn't tell.
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
		// check if the notes have changed, then update them in memory
		notes.ContentsChanged += (s, e) =>
		{
			task.SetNotes(notes.Text);
		};
		Add(notes);

	}
}
