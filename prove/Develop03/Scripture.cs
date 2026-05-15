using System.Text.Json;
class Scripture
{
    private Reference _reference;
    private List<Word> _text;

    public Scripture(string reference,int index)
    {
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
        using (StreamReader reader = new StreamReader(books[index-1]))
        {
            Book scrip = JsonSerializer.Deserialize<Book>(reader.ReadToEnd());
            foreach(Verse verse in scrip.verses)
            {
                foreach(int i in _reference.GetVerseList()){
                    if(verse.reference == $"{_reference.GetEmptyVerseRef()}{i}")
                        ParseText(verse.text);
                }
            }
        }
    }
    public void ParseText(string text)
    {
        string[] words = text.Split(" ");
        foreach (string word in words)
        {
            _text.Add(new Word(word));
            _text.Add(new Word(" "));
        }
        _text.Add(new Word("\n"));
    }
    public override string ToString()
    {
        string ret = "";
        foreach(Word w in _text)
        {
            ret += w.Get();
        }
        return ret;
    }
    public void Write()
    {
        Console.WriteLine(_reference.ToString());
        foreach(Word w in _text)
        {
            Console.Write(w.Get());
        }
    }
    public bool HideSome()
    {
        Random rnd = new Random();
        bool isHidden=true;
        foreach(Word w in _text)
        {
            if (rnd.Next(0, 3)==1)
                w.Hide();
            if(!w.IsHidden())
                isHidden=false;
        }
        return isHidden;
    }
    public void Reset()
    {
        foreach(Word w in _text)
        {
            if(w.IsHidden())
                w.Toggle();
        }
    }
    public bool Test()
    {
        this.Reset();
        string[] fullScripture = this.ToString().Trim().Split("\n");
        int count=0;
        bool passed = false;
        foreach(string verse in fullScripture)
        {
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