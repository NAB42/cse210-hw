/* 2026.05.15 Nathan Boulton
 * This is for JSON Serializing.
 * In this case, the attributes must be public, because the JSON Serializer needs 
 * to be able to access the attributes specifically, due to its design nature. 
 * Basically these 2 classes are used to convert the JSON to strings for use in 
 * the program. 
 */
public class Verse
{
    // Both reference and text are given getters and setters for the 
    // Deserializer.
    public string reference { get; set; }
    public string text { get; set; }

}

public class Book
{
    // Same here.
    public List<Verse> verses { get; set; }
}