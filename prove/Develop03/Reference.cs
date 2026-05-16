/* 2026.05.15 Nathan Boulton
 * This is the reference class. It is responsible for parsing the reference 
 * string into something more usable. It's main claim to fame is handling 
 * multiple verses. */
using System.Text.RegularExpressions;
public class Reference
{
    /* Attributes */
    private string _book;
    private int _chapter;
    private string _verse;


    /* Constructors */
    public Reference()
    {
        _book = "Genesis";
        _chapter = 1;
        _verse = "1";
    }
    public Reference(string name, int chapter, string verse)
    {
        _book = name;
        _chapter = chapter;
        _verse = verse;
    }
    public Reference(string reference)
    {
        this.CreateReference(reference);
    }


    /* Methods */

    // Overrides the Object class ToString() and returns it like a normal reference.
    public override string ToString()
    {
        return $"{_book} {_chapter}:{_verse}";
    }

    // This takes a string and uses Regular Expressions to parse the string 
    // into something usable by the object (and other classes!).
    public string CreateReference(string reference)
    {
        // This works backwards. 
        // First it gets the verses and stores it in the attribute.
        string pattern = "[0-9-]*$";
        _verse = Regex.Match(reference, pattern).Value;
        // Cuts of the verses and colon so the rest can be parsed.
        reference = reference.Remove(reference.Length - (_verse.Length + 1));
        // Then it looks for the chapter and stores that.
        pattern = "[0-9]*$";
        string newChapter = Regex.Match(reference, pattern).Value;
        _chapter = int.Parse(newChapter);
        reference = reference.Remove(reference.Length - (newChapter.Length + 1));
        // After the rest is cut off, the book is all that's left.
        _book = reference;
        return this.ToString();
    }

    // Some evil little Getters
    public string GetName()
    {
        return _book;
    }
    public int GetChapter()
    {
        return _chapter;
    }
    public string GetVerses()
    {
        return _verse;
    }

    // The purpose of this method is for rendering 1 verse at a time
    // for the JSON deserializer.
    public string GetEmptyVerseRef()
    {
        return $"{_book} {_chapter}:";
    }

    // This method gets the verses in a list, so that all of them can be 
    // individually displayed.
    public List<int> GetVerseList()
    {
        // This handles one verse options. Returns a list with 1 cell.
        if (int.TryParse(_verse, out int verse))
        {
            return new List<int> { verse };
        }
        else
        {
            // Handles multiple verses. Uses Regex.Match() to create the range 
            // groups, then iterates through it to add the numbers.
            Match match = Regex.Match(_verse, @"(\d+)-(\d+)");
            int start = int.Parse(match.Groups[1].Value);
            int end = int.Parse(match.Groups[2].Value);
            List<int> list = new List<int>();
            for (int i = start; i <= end; i++)
            {
                list.Add(i);
            }
            return list;
        }
    }
}