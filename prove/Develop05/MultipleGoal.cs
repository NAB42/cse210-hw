/* 06.04.2026 Nathan Boulton
 * The MultipleGoal has a threshold for completions, and the points 
 * awarded is greater once that threshold is met, to motivate users to do 
 * those things many times. These are for things that are hard to do, but not 
 * so hard they can only be completed once. 
 */

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

	// If it's below the threshold, award a normal amount of points. If it's above, award an extra 
	// 10 points for each time completed above the threshold.
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

	public override string Stat()
	{
		return _timesCompleted.ToString();
	}

}
