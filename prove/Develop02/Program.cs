// By Nate Boulton
// The Journal Project is a simple program that stores journal entries in a file for the user.
// Its purpose is to encourage people to write in their journal, and to focus it on the Lord and 
// on the positive aspects. It has a chance to ask one of 3 main questions:
// 1. Something cool that happened today
// 2. Something the user is grateful for
// 3. How the user has seen the hand of the Lord in their life.
// 
// This is part of the "Programming with Classes" curriculum that I am currently in. 
// It dives into file processing, use of classes and objects, abstraction, and method calling.

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal.");

        // I know I was supposed to get the date from the user but this is 
        // much more efficient. And it took me like 5 seconds on Google to find.
        string date = DateOnly.FromDateTime(DateTime.Now).ToString();

        // Variable to determine if the user wants to continue
        string cont="";


        // Prompts user for the filename and constructs the file.
        Console.Write("Enter Journal filename: ");
        Journal journal = new Journal(Console.ReadLine());

        // Ternary operator determining how the program should start, based on 
        // if the Journal is empty or not. If it is, the program jumps straight to 
        // creating a new entry because the other options are useless.
        cont = journal.Exists() ? "0" : "3";

        // This is the menu. It receives user input and follows accordingly.
        // Ends when the user types '4' (obviously)
        while (cont != "6")
        {
            if (cont == "1")
            {
                // Prints out the most recent journal entry.
                Console.WriteLine(journal.GetRecent());
            }
            else if (cont == "2")
            {
                // Prints out all the journal entries the Journal has.
                Console.WriteLine(journal.GetAll());
            }
            else if (cont == "3")
            {
                // Creates a new entry, gives the prompt question, and the user 
                // responds with with their new entry. It is then added to the 
                // Journal.
                Entry entry = new Entry(date);
                entry.DisplayPrompt();
                journal.AddEntry(entry);
                Console.WriteLine("Added to Journal.");
                
            }
            else if (cont == "4")
            {
                journal.WriteAll();
                Console.WriteLine("Journal Saved.");
            }
            else if (cont == "5")
            {
                Console.Write("Enter a new filename: ");
                journal.LoadJournal(Console.ReadLine());

            }
            Console.WriteLine(
            """

            Choose an option (1-6):
            1. Read most recent entry
            2. Read all entries
            3. Create new entry
            4. Save entries to Journal
            5. Load new Journal
            6. Quit

            """);
            cont=Console.ReadLine();
            
        }
        // Write the changes to the journal.csv file.
        journal.WriteAll();
        Console.WriteLine("Journal Saved.");
    }
}