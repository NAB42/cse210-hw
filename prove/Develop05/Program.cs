/* 06.04.2026 Nathan Boulton. Version 1.0.1
 * Welcome to GoalQuest, a Linux CLI-esque game for completing goals.
 *
 * Honestly things are pretty simple here. The premise is that there are a bunch 
 * of goals that the user can complete for points. 
 * The game draws inspiration from bash, in the form of "eternash". The entire game 
 * looks like a Linux distro in the terminal. A lot of the standard, popular commands 
 * are included in this game, although they have very different functions. Each function is 
 * defined in the comments below. 
 * The purpose of this game is to give users a good motivation to complete goals. There can 
 * be multiple users, and it's all stored in game files. 
 *
 */

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
		// This is the version of the game. If there's a different number elsewhere, it's wrong.
		string version = "1.0.1";
		Console.Clear();
		// Here is the login screen. Type anything and if it doesn't exist, it will create a 
		// new user with blank goals.
		Console.WriteLine($"GoalQuest {version}");
		Console.Write("login: ");
		User user = new User(Console.ReadLine());
		Console.WriteLine("\nWelcome to GoalQuest!\n");
		Console.ForegroundColor = ConsoleColor.DarkGreen;
		Console.WriteLine(
				"""
				##################
				####          ####
				###   ######   ###
				###  #############
				###  #############
				###  #####     ###
				###   ######   ###
				####          ####
				##################
				""");
		Console.ResetColor();
		Console.WriteLine($"\nversion {version}\n");
		Console.WriteLine("type 'help' for a list of commands.\n");
		string[] command;
		// So this is the start of the command loop. This is where a user can type 
		// in commands and the game will act accordingly. 
		do
		{
			Console.Write($"[{user.Name()}@goalquest ~]$ ");
			command = Console.ReadLine().Split(" ");
			switch (command[0])
			{
				// This is the ls command. Linux uses this to list directories and files,
				// but in GoalQuest it's used to list the goals and their completion progress
				// for the current user. 
				case "ls":
					user.List();
					break;
				// In Linux, 'pwd' prints out the working directory, or the path that the terminal 
				// is currently opened in. In GoalQuest, it prints the user's total points. 
				case "pwd":
					user.PrintPoints();
					break;
				// 'cd' is used in Linux to "Change Directory", but here it's used to mark a 
				// goal as "Completely Done". Well, in the case of the threshold and eternal 
				// goals not really, but it helps it fit in with 'cd'.
				case "cd":
					user.CompletelyDone();
					break;
				// This is the most complex command (possibly due to a trash design, I don't know).
				// In Linux, the touch command makes a new file. Here, it makes a new goal. 
				case "touch":
					string touch = "";
					string type = "";
					string descr = "";
					string points = "";
					string thresh = "";
					bool mult = false;
					Console.Write(
							"""
							Choose a goaltype:
							1. Single-use Goal
							2. Multi-use Goal (has a threshold)
							3. Eternal Goal (Infinite acheivement)
							>  
							""");
					// Constructs the thing to add to the file
					type = Console.ReadLine();
					touch = type;
					if(touch == "2")
						mult = true;
					touch += ",";
					Console.Write("Enter goal description:\n> ");
					descr = Console.ReadLine();
					touch += descr + ",";
					Console.Write("Enter number of points:\n> ");
					points = Console.ReadLine();
					touch += points;
					if(mult)
					{
						Console.Write("Enter threshold: \n> ");
						thresh = Console.ReadLine();
						touch += "," + thresh;
					}
					using(StreamWriter writer = new StreamWriter("goals",true))
					{
						writer.WriteLine(touch);
					}
					// Immediately loads the goals into memory. This could do with being made a method 
					// later. 
					switch(type)
					{
						case "1":
							user.AddGoal(new SingleGoal(descr,int.Parse(points),false));
							break;
						case "2":
							user.AddGoal(new MultipleGoal(descr,int.Parse(points),0,int.Parse(thresh)));	
							break;
						case "3":
							user.AddGoal(new EternalGoal(descr,int.Parse(points),0));
							break;
					}
					break;
				// This command prints out all of the users and their points. In Linux it's used 
				// to print out the contents of a file.
				case "cat":
					List<User> users = new List<User>();
					foreach(string filePath in Directory.EnumerateFiles("usr"))
					{
						users.Add(new User(Path.GetFileName(filePath)));
					}
					foreach(User usr in users)
					{
						Console.WriteLine($"{usr.Name()}: {usr.TotalPoints()} points");
					}
					break;
				// "Switch User". Same use case in Linux. If the user isn't created a new record is made. 
				case "su":
					user = new User(command[1]);
					break;
				// Prints the current user. Same use case as Linux.
				case "whoami":
					Console.WriteLine(user.Name());
					break;
				// Prints out all of the commands and a quick explanation. 
				case "help":
					Console.WriteLine(File.ReadAllText("help.txt"));
					break;
				// Prints out the version. Similar use case in Linux.
				case "uname":
					Console.WriteLine($"GoalQuest v{version}");
					break;
				// Exits the program. 
				case "exit":
					user.SaveGoals();
					return;
				// root-only command: removes whatever user is specified. In Linux rm removes files 
				// and directories. 
				case "rm":
					if(user.Name() == "root")
					{
						Console.Write($"Are you sure you want to remove {command[1]} (y/N)?");
						if(Console.ReadLine().ToLower() == "y")
							File.Delete($"usr/{command[1]}");
					}
					else
					{
						Console.WriteLine("error: permission denied.");
					}
					Console.WriteLine();
					break;
				// If I type 'egiurgewoir' this is what will happen.
				default:
					Console.WriteLine($"eternash: {command[0]}: command not found.");
					break;
			}
			// After every command the user's goals are saved. 
			user.SaveGoals();
		}
		while(true);
    }
}
