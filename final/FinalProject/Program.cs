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

		/*using Window window = new(){ Title = "Kanban (Esc to quit)" };
		Label label = new()
		{
			Text = "Welcome to TuiTasks",
			X = Pos.Center(),
			Y = Pos.Center()
		};
		window.Add(label);*/
		try{
		using MainWindow window = new MainWindow(new Project(new List<Task>(){new EventTask("Do the dishes","Get them done",DateTime.Now),new Task(),new Task()}),app);

		app.Run(window);
		}
		catch (Exception e)
		{
			app.Dispose();
			Console.WriteLine(e);
			return;
		}
		app.Dispose();
	}
}
