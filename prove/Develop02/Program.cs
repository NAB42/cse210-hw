using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal.");
        string date = DateOnly.FromDateTime(DateTime.Now).ToString();
        string cont="";
        Journal journal = new Journal();
        cont = journal.Exists() ? "0" : "3";
        while (cont != "4")
        {
            if (cont == "1")
            {
                Console.WriteLine(journal.GetRecent());
            }
            else if (cont == "2")
            {
                Console.WriteLine(journal.GetAll());
            }
            else if (cont == "3")
            {
                Entry entry = new Entry(date);
                entry.DisplayPrompt();
                journal.AddEntry(entry);
                Console.WriteLine("Added to Journal.");
                
            }
            Console.WriteLine(
            """
            Choose an option (1-4):
            1. Read most recent entry
            2. Read all entries
            3. Create new entry
            4. Quit
            """);
            cont=Console.ReadLine();
            
        }
        journal.WriteAll();
        Console.WriteLine("Journal Saved.");
    }
}