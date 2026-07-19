/** 2026 Nathan Boulton
 * This is the help window. It displays the keyboard bindings so that the user
 * knows what's going on. 
 */

public class HelpDialog : Dialog
{
    public HelpDialog()
    {
        Title = "Help (Esc)";
        Width = Dim.Percent(60);
        Height = Dim.Percent(60);

        TextView helpText = new TextView
        {
            X = 0, Y = 0,
            Width = Dim.Fill(), Height = Dim.Fill(1),
            ReadOnly = true,
            Text = 
					"""
					Welcome to the Task Board! Here you will find a nice 3 column, keyboard-
					controlled Kanban Board designed to help you organize all that stuff 
					you need to do. Here is a list of all the keybinds you will need:

					Ctrl+T - move task to To Do
					Ctrl+P - move task to In Progress
					Ctrl+D - move task to Done
					Ctrl+S - save the taskboard
					Ctrl+H - open this window
					Ctrl+N - Create a new task
					Ctrl+R - Delete a task (WARNING: THIS IS NOT UNDOABLE!)
					Tab / Shift+Tab - switch columns
					Enter - open task details
					"""
        };
        Add(helpText);

        }
}
