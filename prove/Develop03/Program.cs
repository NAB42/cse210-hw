using System;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        // Console.Write("Enter a scripture:\n> ") ;
        // Reference r = new Reference(Console.ReadLine());
        // Console.WriteLine("Book is " +r.GetName());
        // Console.WriteLine("Chatper is "+r.getChapter());
        // Console.WriteLine("Verses are "+r.GetVerses());
        // using (StreamReader reader = new StreamReader("book-of-mormon-flat.json"))
        // {
        //     string js = reader.ReadToEnd();
        //     Book s = JsonSerializer.Deserialize<Book>(js);
        //     foreach(Verse v in s.verses)
        //     {
        //         if(v.reference == "2 Nephi 2:25")
        //         {
        //             Console.WriteLine(v.text);
        //         }
        //     }
        // }
        // Word w = new Word("Test");
        // Console.Write("> ");
        // if (Console.ReadLine() == "y")
        //     w.Toggle();
        // Console.WriteLine($"This is a {w.Get()}. Does it work?");
        Reference reff = new Reference("2 Nephi 2:22-25");
       foreach (int i in reff.GetVerseList())
        {
            Console.WriteLine(i);
        }
    }
}