public class Verse
{
    public string reference {get;set;}
    public string text{get;set;}

}

public class Book
{
    public List<Verse> verses{get;set;}
}