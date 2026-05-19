public class Assignment
{
    /* Attributes */
    private string _studentName;
    private string _topic;

    /* Cosntructors */
    public Assignment(string name,string topic)
    {
        _studentName=name;
        _topic=topic;
    }

    /* Methods */
    public string GetSummary()
    {
        return $"Name: {_studentName}, Topic: {_topic}";
    }
    public string GetName()
    {
        return _studentName;
    }

}