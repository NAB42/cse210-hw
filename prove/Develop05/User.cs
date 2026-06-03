public class User
{
	private string _name;
	private List<Goal> goals = new List<Goal>();
	public User(string name)
	{
		_name = name;
		try{
			using (StreamReader reader = new StreamReader($"usr/{_name}"))
			{
				
			}
		}
		catch (FileNotFoundException)
		{
			File.Create($"/usr/{_name}").Dispose();
		}
	}
}
