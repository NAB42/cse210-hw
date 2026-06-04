/* 06.04.2026 Nathan Boulton
 * This is the abstract class for all of the Goals. It doesn't have 
 * too much. Just sets the tone for the 3 derived goal types.
 */

public abstract class Goal
{
	// Common attributes
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
	public abstract string Stat();
}
