/* 06.04.2026 Nathan Boulton
 * This is one of the derived goals, the EternalGoal. This goal 
 * can be done over and over again for the same amount of points.
 */

public class EternalGoal : Goal
{
	private int _timesCompleted;

	public EternalGoal(string description, int points, int count)
	{
		this.SetDescription(description);
		this.SetPoints(points);
		_timesCompleted = count;
	}

	public int TimesCompleted()
	{
		return _timesCompleted;
	}

	public override void Complete()
	{
		_timesCompleted++;
	}

	// Simple calculation for points. 
	public override int CalculatePoints()
	{
		return this.Points() * _timesCompleted;
	}

	public override string ToString()
	{
		return $"[{_timesCompleted}/∞] {this.Description()} ({this.Points()} points each)";
	}

	public override string Stat()
	{
		return _timesCompleted.ToString();
	}
} 
