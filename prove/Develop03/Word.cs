/* 2026.05.15 Nathan Boulton
 * This is the Word class. it's honestly pretty simple, which is 
 * obvious given it's only 30 lines in length. All it does is take 
 * words and makes them hidden if needed. 
 */
using System.Text.RegularExpressions;

public class Word
{
    /* Attributes */
    private string _word;
    private bool _hidden;


    /* Constructor */

    // Only 1 constructor. I don't see a point to a default one.
    public Word(string word)
    {
        _word = word;
        _hidden = false;
    }


    /* Methods */

    // Toggles if it's hidden or not.
    public void Toggle()
    {
        _hidden = !_hidden;
    }

    // Straight up hides the 
    public void Hide()
    {
        _hidden = true;
    }
    public string Get()
    {
        // I know this is terrible practice, but I love ternary operators and I 
        // wanted to use it somewhere. 
        // returns the hidden or unhidden word.
        return _hidden ? Regex.Replace(_word, ".", " ") : _word;
    }
    public bool IsHidden()
    {
        return _hidden;
    }
}