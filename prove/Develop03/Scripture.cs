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
        foreach(Word w in _text)
        {
            Console.Write(w.Get());
        }
    }
}