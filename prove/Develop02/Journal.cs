

using System.IO;
using System.Text.RegularExpressions;
class Journal
{
    // Attributes
    private List<Entry> _entries = new List<Entry>();
    private bool _exists;

    // Constructors
    public Journal()
    {
        using(StreamReader reader = new StreamReader("journal.csv"))
        {
            try
            {
                int lineCount = File.ReadLines("journal.csv").Count();
                _exists = true;
                for (int i = 0; i <= lineCount-1; i++)
                {
                    string csvLine = reader.ReadLine();
                    string[] entry = csvLine.Split(","); 
                    foreach(string e in entry)
                    {
                        Console.WriteLine(e);
                    }
                    Console.WriteLine(entry[2].Length);
                    string fixedResponse = entry[2].Replace("\u001B",",");
                    Console.WriteLine(fixedResponse.Length);
                    _entries.Add(new Entry(entry[0],int.Parse(entry[1]),fixedResponse));
                }
                
            }
            catch (NullReferenceException)
            {
               _exists = !true; 
            }
            catch (IndexOutOfRangeException n)
            {
                /*Console.WriteLine("It broke.");
                Console.WriteLine(n);
                Console.WriteLine(this.GetAll());*/
            }
        }
    }

    // Methods
    public void WriteAll()
    {
        string final = "";
        foreach (Entry entry in _entries)
        {
            entry.FixCommas();
            final += $"{entry.toCSV()}\n";
        }
        using (StreamWriter writer = new StreamWriter("journal.csv"))
        {
            writer.WriteLine(final);
        }
    }
    public string GetAll()
    {
        string final = "";
        foreach (Entry entry in _entries)
        {
            final += $"{entry.GetEntry()}\n";
        }
        return final;
    }
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }
    public bool Exists()
    {
        return _exists;
    }
    public string GetRecent()
    {
        return _entries[_entries.Count-1].GetEntry();
    }

}