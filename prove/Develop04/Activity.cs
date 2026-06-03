/* 06.02.2026 Nathan Boulton
 * This is the parent Activity class. Never directly instantiated as an
 * object, but instead used for its common attributes.
 * Includes Begin and End methods that are the same for every activity.
 */

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
	public string GetDescription()
	{
		return _description;
	}
	public string GetName()
	{
		return _name;
	}
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

	// This is where the input of duration happens.
	public void Begin()
	{
		Console.Write("Welcome! Please enter the number of seconds you want this to last:\n> ");
		int seconds = int.Parse(Console.ReadLine());
		this.SetDuration(seconds);	
		Console.WriteLine(this.ToString());
	}
	public void End()
	{
		Console.WriteLine("Congratulations! You did a good job. Hopefully you feel more mindful now.");
		Thread.Sleep(3000);
	}
}
