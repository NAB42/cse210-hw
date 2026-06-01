public class Activity
{
    /* Attributes */
    private string _name;
    private string _description;
    private int _duration;

    /* Constructors */
    public Activity(string name,string description)
    {
        _name=name;
        _description=description;
    }

    /* Methods */
    public void SetDuration(int seconds)
    {
        _duration=seconds;
    }
	public int GetDuration()
	{
		return _duration;
	}
	public override string ToString()
	{
		return $"Welcome to {_name}\n{_description}";
	}
	public void Begin()
	{
		Console.Write("Welcome! Please enter the number of seconds you want this to last:\n> ");
		int seconds = int.Parse(Console.ReadLine());
		this.SetDuration(seconds);
	}
	public void End()
	{
		Console.WriteLine("Congratulations! You did a good job. Hopefully you feel more mindful now.");
		Thread.Sleep(3000);
	}
}
