using System.Text.RegularExpressions;

class Word
{
    private string _word;
    private bool _hidden;

    public Word(string word)
    {
        _word=word;
        _hidden=false;
    }

    public void Toggle()
    {
        _hidden=!_hidden;
    }
    public void Hide()
    {
        _hidden = true;
    }
    public string Get()
    {
        return _hidden ? Regex.Replace(_word,"."," ") : _word;
    }
}