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
    public int GetChapter()
    {
        return _chapter;
    }
    public string GetVerses()
    {
        return _verse;
    }
    public string GetEmptyVerseRef()
    {
        return $"{_book} {_chapter}:";
    }
    public List<int> GetVerseList()
    {
        if(int.TryParse(_verse,out int verse))
        {
            return new List<int>{verse};
        }
        else
        {
            //Console.WriteLine(_verse);
            Match match = Regex.Match(_verse,@"(\d+)-(\d+)");
            //Console.WriteLine(match.Groups[0].Value);
            int start = int.Parse(match.Groups[1].Value);
            //Console.WriteLine(match.ToString());
            Console.WriteLine("Start: "+start);
            int end = int.Parse(match.Groups[2].Value);
            Console.WriteLine("End: "+end);
            List<int> list = new List<int>();
            for (int i = start; i <= end; i++)
            {
                list.Add(i);
            }
            return list;
        }
    }
}