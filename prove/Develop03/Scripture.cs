/* 2026.05.15 Nathan Boulton
 * This is the Scripture class. It's where a large portion of the processing
 * happens. The purpose of this class is to create an object with a Reference 
 * and a list of Word objects that can be manipulated accordingly.
 * This is where the JSON is converted, where the test is ran, and where the 
 * text is parsed and created.
 */
using System.Text.Json;
public class Scripture
{
    /* Attributes */
    private Reference _reference;
    private List<Word> _text;


    /* Constructors */
    public Scripture(string reference,int index)
    {
        // This is the list of JSON files. There are 5 of them.
        string[] books =
        {
            "old-testament-flat.json",
            "new-testament-flat.json",
            "book-of-mormon-flat.json",
            "doctrine-and-covenants-flat.json",
            "pearl-of-great-price-flat.json"
        };
        _reference = new Reference(reference);
        _text = new List<Word>();
        // Opens up the file that corresponds with what the user chooses.
        // 'index' - 1 is to convert from user-friendly counting to computer 
        // indexing.
        using (StreamReader reader = new StreamReader(books[index-1]))
        {
            // JSON conversion
            Book scrip = JsonSerializer.Deserialize<Book>(reader.ReadToEnd());
            foreach(Verse verse in scrip.verses)
            {
                // Adds the text for each verse using the GetVerseList() method
                foreach(int i in _reference.GetVerseList()){
                    if(verse.reference == $"{_reference.GetEmptyVerseRef()}{i}")
                        ParseText(verse.text);
                }
            }
        }
    }


    /* Methods */

    // This method creates the Word List from the string.
    public void ParseText(string text)
    {
        // Split the text into an array of single word strings.
        string[] words = text.Split(" ");
        foreach (string word in words)
        {
            // Make the strings into Word objects, add spaces back.
            _text.Add(new Word(word));
            _text.Add(new Word(" "));
        }
        // Add a newline to separate the verses.
        _text.Add(new Word("\n"));
    }

    // This overrides the method inherited from the Object class.
    // recreates the Word list into a usable string to print/analyze.
    public override string ToString()
    {
        string ret = "";
        foreach(Word word in _text)
        {
            ret += word.Get();
        }
        return ret;
    }

    // This writes the verses to the Console.
    public void Write()
    {
        Console.WriteLine(_reference.ToString());
        foreach(Word word in _text)
        {
            Console.Write(word.Get());
        }
    }

    // This method, by random chance, chooses certain words to hide. 
    // It then returns a boolean depending on if the whole verse is hidden
    // or not.
    public bool HideSome()
    {
        Random rnd = new Random();
        bool isHidden=true;
        foreach(Word word in _text)
        {
            // Right now it's a 1 in 3 chance. One day I'll make it customizable
            // by the user in a config menu maybe.
            if (rnd.Next(0, 3)==1)
                word.Hide();
            if(!word.IsHidden())
                isHidden=false;
        }
        return isHidden;
    }

    // Resets the word. If there's any hidden words they are unhidden.
    public void Reset()
    {
        foreach(Word word in _text)
        {
            if(word.IsHidden())
                word.Toggle();
        }
    }

    // The test! Bane of all students' existences. 
    public bool Test()
    {
        this.Reset();
        // Splits the verses
        // Also trims the newline or space off of the end so the user doesn't get instafailed
        string[] fullScripture = this.ToString().Trim().Split("\n");
        int count=0;
        bool passed = false;
        foreach(string verse in fullScripture)
        {
            // Writes out the verse number, then checks if the response matches the verse.
            Console.Write($"Verse {_reference.GetVerseList()[count]}:\n❯ ");
            if(Console.ReadLine() == verse)
                passed=true;
            else
                passed=false;
            count++;
        }
        return passed;
    }
}