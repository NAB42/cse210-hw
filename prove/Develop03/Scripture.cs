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
        using (StreamReader reader = new StreamReader(books[index-1]))
        {
            Book scrip = JsonSerializer.Deserialize<Book>(reader.ReadToEnd());
            foreach(Verse verse in scrip.verses)
            {
                
            }
        }
    }
    
}