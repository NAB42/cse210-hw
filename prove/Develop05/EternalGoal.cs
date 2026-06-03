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
	public override int CalculatePoints()
	{
		return this.Points() * _timesCompleted;
	}
	public override string ToString()
	{
		return $"[{_timesCompleted}/∞] {this.Description()} ({this.Points()} points each)";
	}
} 
