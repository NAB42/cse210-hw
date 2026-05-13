// By Nate Boulton
// This is the Journal class. It determines how the Journal object works. Refer to the main
// program for more details.
using System.IO;
class Journal
{
    /* Attributes */
    private List<Entry> _entries = new List<Entry>();
    private bool _exists;
    private string _filename;


    /* Constructors */
    public Journal(string filename)
    {
        LoadJournal(filename);
    }


    /* Methods */

    public void LoadJournal(string filename)
    {
        _entries.Clear();
        _filename = filename;
        try
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                try
                {
                    int lineCount = File.ReadLines(filename).Count();
                    _exists = true;
                    // A for loop to go through each line and create an Entry out of them
                    // to parse into the List. 
                    for (int i = 0; i <= lineCount; i++)
                    {
                        string csvLine = reader.ReadLine();
                        string[] entry = csvLine.Split(",");
                        // Because CSV files are comma separated, this takes it into account.
                        // Refer to the Entry class for more info.
                        string fixedResponse = entry[2].Replace("\u001B", ",");
                        // Adds the Entry to the List.
                        _entries.Add(new Entry(entry[0], int.Parse(entry[1]), fixedResponse));
                    }

                }
                // This accounts for the lack of a journal. Obviously if the file is empty
                // nothing can be loaded in, so it sets the _exists attribute to false.
                catch (NullReferenceException)
                {
                    _exists = !true;
                }

                // This accounts for any extra lines in the CSV file. It just keeps 
                // going as if nothing happened.
                catch (IndexOutOfRangeException) { }
            }
        }

        // If the file doesn't exist, it is created.
        catch (FileNotFoundException)
        {
            using (File.Create(filename)) { }
            _exists = !true;
        }
    }

    // Writes all the changes to the CSV file.
    public void WriteAll()
    {
        string final = "";
        // First it creates a string that holds the entire Journal,
        foreach (Entry entry in _entries)
        {
            entry.FixCommas();
            final += $"{entry.toCSV()}\n";
        }
        // And then it writes that whole string to the file.
        using (StreamWriter writer = new StreamWriter(_filename))
        {
            writer.WriteLine(final);
        }
    }

    // Retreives all the entries and returns them as a big string, much 
    // like WriteAll() but in a different format.
    public string GetAll()
    {
        string final = "";
        foreach (Entry entry in _entries)
        {
            final += $"{entry.GetEntry()}\n";
        }
        return final;
    }

    // Appends the given entry to the List.
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    // Accesses the encapsulated _exists bool.
    public bool Exists()
    {
        return _exists;
    }

    // Retreives the most recent entry put into the Journal.
    // The -1 accounts for the index offset that arrays have.
    public string GetRecent()
    {
        return _entries[_entries.Count - 1].GetEntry();
    }

    // Ok so this finds 3 statistics to display, to help the journaler
    // focus on improving or see their progress. The purpose of this whole 
    // program is to help people to journal more. This allows them to see 
    // Actual data.
    public string GetStats()
    {
        // This section deals with determining the number of entries per day.
        DateTime firstDay = _entries[0].GetDate();
        DateTime lastDay = _entries[_entries.Count - 1].GetDate();
        double eavg = _entries.Count / (lastDay - firstDay).TotalDays;
        // This finds the average size of the entries, to see how much they are writing.
        int avgSize = 0; int count = 0;
        foreach (Entry entry in _entries)
        {
            avgSize += entry.GetResponse().Length;
            count++;
        }
        avgSize /= count;
        // Returns a multiline string with that information.
        return
        $"""
        {_filename} Statistics:
        Number of Entries: {_entries.Count}
        Average entries per day: {Math.Round(eavg, 2)}
        Average entry size: {avgSize} characters
        """;
    }
}