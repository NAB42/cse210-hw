public abstract class Goal
{
	private string _description;
	private int _points;

	// Getters
	public string Description()
	{
		return _description;
	}
	public int Points()
	{
		return _points;
	}

	// Setters
	public void SetDescription(string descr)
	{
		_description = descr;
	}
	public void SetPoints(int points)
	{
		_points = points;
	}

	// Abstract Methods
	public abstract void Complete();
	public abstract int CalculatePoints();
	public abstract override string ToString();
}
