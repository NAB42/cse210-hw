global using System;
global using Terminal.Gui;
global using Terminal.Gui.App;
global using Terminal.Gui.Views;
global using Terminal.Gui.ViewBase;

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
		using MainWindow window = new MainWindow(new Project());

		app.Run(window);	
	}
}
