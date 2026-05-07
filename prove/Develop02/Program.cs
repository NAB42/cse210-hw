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
                
            }
            else if (cont == "2")
            {
                
            }
            else if (cont == "3")
            {
                Entry entry = new Entry(date);
                entry.DisplayPrompt();
                
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
    }
}