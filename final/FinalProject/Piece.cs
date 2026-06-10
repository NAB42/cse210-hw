public abstract class Piece
{
	private Location _location;
	private bool _captured;

	public abstract void Move(Location loc);
	public abstract bool CheckLegality(Location loc);
	public void Capture()
	{
		_captured = true;
	}
	public Location GetLocation()
	{
		return _location;
	}
	public bool IsCaptured()
	{
		return _captured;
	}
	protected void SetLocation(Location loc)
	{
		_location = loc;
	}
	public override string ToString()
	{
		string cap = _captured ? "Captured" : "Active";
		return $"{cap} Piece at {_location.ToString()}";
	}
}
