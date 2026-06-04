/*06.04.2026 Nathan Boulton
 * The SingleGoal is a unique type of goal that only awards points the 
 * first time it has been completed. They generally have more points. 
 */

public class SingleGoal : Goal 
{
	// Notice _completed is a boolean and not an int. One time.
	private bool _completed;

	public SingleGoal(string description, int points, bool done)
	{
		this.SetDescription(description);
		this.SetPoints(points);
		_completed = done;
	}

	public bool Completed()
	{
		return _completed;
	}

	public override void Complete()
	{
		_completed = true;
	}

	// If it's completed, award points. If not, zero.
	public override int CalculatePoints()
	{
		return _completed ? this.Points(): 0;
	}

	// An [X] is marked if it's done, otherwise it's empty.
	public override string ToString()
	{
		string done = _completed ? "X" : " ";
		return $"[{done}] {Description()} ({Points()} Points)";
	}

	public override string Stat()
	{
		return _completed.ToString().ToLower();
	}
}
