using System.Text.RegularExpressions;
class Reference
{
    private string _book;
    private int _chapter;
    private string _verse;

    public Reference()
    {
        _book="Genesis";
        _chapter=1;
        _verse="1";
    }
    public Reference(string name,int chapter,string verse)
    {
        _book=name;
        _chapter=chapter;
        _verse=verse;
    }
    public Reference(string reference)
    {
        this.CreateReference(reference);
    }

    public override string ToString()
    {
        return $"{_book} {_chapter}:{_verse}";
    }

    public string CreateReference(string reference)
    {
        string pattern = "[0-9-]*$";
        _verse = Regex.Match(reference,pattern).Value;
        reference = reference.Remove(reference.Length-(_verse.Length+1));
        pattern = "[0-9]*$";
        string newChapter = Regex.Match(reference,pattern).Value;
        _chapter = int.Parse(newChapter);
        reference = reference.Remove(reference.Length-(newChapter.Length+1));
        _book = reference;
        return this.ToString();
    }
    public string GetName()
    {
        return _book;
    }
    public int getChapter()
    {
        return _chapter;
    }
    public string GetVerses()
    {
        return _verse;
    }
}