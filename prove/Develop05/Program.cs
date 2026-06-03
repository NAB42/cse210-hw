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
			Console.Write($"[{user}@goalquest ~]$ ");
			command = Console.ReadLine().Split(" ");
			Console.WriteLine();
			switch (command[0])
			{
				case "ls":
					user.List();
					break;
				case "pwd":
					Console.WriteLine("WIP :)");
					break;
				case "cd":
					user.CompletelyDone();
					break;
				case "cat":
					Console.WriteLine("WIP :)");
					break;
				case "su":
					Console.WriteLine("WIP :)");
					break;
				case "whoami":
					Console.WriteLine(user);
					break;
				case "help":
					Console.WriteLine(File.ReadAllText("help.txt"));
					break;
				case "exit":
					return;
				default:
					Console.WriteLine($"eternash: {command[0]}: command not found.");
					break;
			}
		}
		while(true);
    }
}
