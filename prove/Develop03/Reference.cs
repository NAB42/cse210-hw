class Reference
{
    private string _name;
    private int _chapter;
    private int _verse;

    public Reference()
    {
        _name="Genesis";
        _chapter=1;
        _verse=1;
    }
    public Reference(string name,int chapter,int verse)
    {
        _name=name;
        _chapter=chapter;
        _verse=verse;
    }

    public override string ToString()
    {
        return $"{_name} {_chapter}:{_verse}";
    }
}