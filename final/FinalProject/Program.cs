/** 2026 Nathan Boulton
 *  
 *
 *
 *
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
			using MainWindow window = new MainWindow(proj,app,() => proj.Save());

			app.Run(window);	
		}
		catch (Exception e)
		{
			app.Dispose();
			Console.WriteLine(e);
			return;
		}
		proj.Save();
		app.Dispose();
	}
}
