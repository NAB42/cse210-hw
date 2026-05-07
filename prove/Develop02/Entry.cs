public class Entry
{
    // Attributes
    private List<string> _prompts = new List<string>{"Test","Test2","Test3"};
    private string _date;
    private string _response;
    private int _count;

    // Constructors
    public Entry(string date,int count,string response)
    {
        _date = date;
        _count = count;
        _response = response;
    }
    public Entry(string date)
    {
        _date = date;
    }

    // Methods
    public string toCSV()
    {
        return $"{_date},{_count},{_response}";
    }
    public string GetEntry()
    {
        return $"{_date}\n{_prompts[_count]}\n{_response}";
    }
    public void DisplayPrompt()
    {
        _count = new Random().Next(0,3);
        Console.Write(_date+": ");
        Console.WriteLine(_prompts[_count]);
        _response = Console.ReadLine(); 
    }
    public void SetResponse(string response)
    {
        _response=response;
    }
}