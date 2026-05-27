public class Activity
{
    /* Attributes */
    protected string _name;
    protected string _description;
    protected int _duration;

    /* Constructors */
    public Activity(string name,string description)
    {
        _name=name;
        _description=description;
    }

    /* Methods */
    public string GetInfo()
    {
        return $"{_name} Activity:\n{_description}";
    }
    public void SetDuration(int seconds)
    {
        _duration=seconds;
    }
	public void Begin(){
		Console.Write("Welcome! Please enter the number of seconds you want this to last:\n> ");
		int seconds = int.Parse(Console.ReadLine());
		this.SetDuration(seconds);
	}
}
