public class MathAssignment : Assignment
{
    private double _section;
    private string _problems;
    public MathAssignment(string name,string topic,double section,string problems) : base(name,topic)
    {
        _section=section;
        _problems=problems;
    }
    public string GetHomeworkList()
    {
        return $"Section {_section} Problems {_problems}";
    }
}