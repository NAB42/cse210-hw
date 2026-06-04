using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
		string version = "1.0.0";
		Console.Clear();
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
		do
		{
			Console.Write($"[{user.Name()}@goalquest ~]$ ");
			command = Console.ReadLine().Split(" ");
			switch (command[0])
			{
				case "ls":
					user.List();
					break;
				case "pwd":
					user.PrintPoints();
					break;
				case "cd":
					user.CompletelyDone();
					break;
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
				case "su":
					user = new User(command[1]);
					break;
				case "whoami":
					Console.WriteLine(user.Name());
					break;
				case "help":
					Console.WriteLine(File.ReadAllText("help.txt"));
					break;
				case "uname":
					Console.WriteLine($"GoalQuest v{version}");
					break;
				case "exit":
					user.SaveGoals();
					return;
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
				default:
					Console.WriteLine($"eternash: {command[0]}: command not found.");
					break;
			}
			user.SaveGoals();
		}
		while(true);
    }
}
