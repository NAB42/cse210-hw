public class SingleGoal : Goal 
{
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
	public override int CalculatePoints()
	{
		return _completed ? this.Points(): 0;
	}
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
