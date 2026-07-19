/** 2026 Nathan Boulton
 * Welcome to the Task Manager Board. I'm sorry, I couldn't come up with a good name.
 * This program is a 3 column Kanban Board for monitoring tasks that are To Do, In Progress,
 * and Done. 
 * There are 4 kinds of Tasks: Normal task, a checklist task, a repeating chore task, and an 
 * event task. Each has a slightly different function but all have names, descriptions, and 
 * places for notes. 
 * This project uses Terminal.Gui, a library designed to make TUIs easier to build.
 * It is keyboard based and can be completely navigated through the keyboard, although the 
 * mouse can also be used if desired with limited functionality. 
 */

global using System;
global using Terminal.Gui;
global using Terminal.Gui.App;
global using Terminal.Gui.Views;
global using Terminal.Gui.ViewBase;
global using Terminal.Gui.Input;

public class Program
{
	public static void Main(string[] args)
	{
		using IApplication app = Application.Create();
		app.Init();
		Group proj = new Group();
		proj.Load();
		try{
			// Starts up the main window.
			using MainWindow window = new MainWindow(proj,app,() => proj.Save());
			app.Run(window);	
		}
		catch (Exception e)
		{
			// If something breaks, end the program and print the exception. 
			app.Dispose();
			Console.WriteLine(e);
			return;
		}
		// When the user is done, the program ends and saves the existing tasks.
		proj.Save();
		app.Dispose();
	}
}
