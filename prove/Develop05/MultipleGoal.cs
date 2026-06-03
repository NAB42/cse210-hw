public class MultipleGoal : Goal
{
	private int _timesCompleted;
	private int _threshold;

	 public MultipleGoal(string description, int points, int count, int threshold)
	{
		this.SetDescription(description);
		this.SetPoints(points);
		_timesCompleted = count;
		_threshold = threshold;
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
		return _timesCompleted > _threshold 
			? this.Points() * _timesCompleted + (_timesCompleted - _threshold) * 10
			: this.Points() * _timesCompleted;
	}
	public override string ToString()
	{
		return $"[{_timesCompleted}/{_threshold}] {Description()} ({Points()} Points each)";
	}

}
