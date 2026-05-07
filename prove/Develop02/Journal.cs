

using System.IO;
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
                for (int i = 0; i <= lineCount; i++)
                {
                    string csvLine = reader.ReadLine();
                    string[] entry = csvLine.Split(","); 
                    _entries.Add(new Entry(entry[0],int.Parse(entry[1]),entry[2]));
                }
                _exists = true;
            }
            catch (NullReferenceException)
            {
               _exists = !true; 
            }
        }
    }

    // Methods
    public void WriteAll()
    {
        string final = "";
        foreach (Entry entry in _entries)
        {
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

}