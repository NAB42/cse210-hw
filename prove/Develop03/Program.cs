using System;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a scripture:\n> ") ;
        Reference r = new Reference(Console.ReadLine());
        Console.WriteLine("Book is " +r.GetName());
        Console.WriteLine("Chatper is "+r.getChapter());
        Console.WriteLine("Verses are "+r.GetVerses());
        using (StreamReader reader = new StreamReader("book-of-mormon-flat.json"))
        {
            string js = reader.ReadToEnd();
            var s = JsonSerializer.Deserialize<Book>(js);
            foreach(Verse v in s.verses)
            {
                Console.WriteLine(v.reference);
            }
        }
    }
}