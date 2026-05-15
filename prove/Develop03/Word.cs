using System.Text.RegularExpressions;

class Word
{
    string _word;
    bool _hidden;

    public Word(string word)
    {
        _word=word;
        _hidden=false;
    }

    public void Toggle()
    {
        _hidden=!_hidden;
    }
    public string Get()
    {
        return _hidden ? Regex.Replace(_word,"."," ") : _word;
    }
}