public class Queen : Piece
{
	public Queen(Location location)
	{
		this.SetLocation(location);
	}
	public Queen()
	{
		this.SetLocation(new Location("A4"));
	}
	public override void Move(Location loc)
	{
		if(CheckLegality(loc))
				this.SetLocation(loc);
	}
	public override bool CheckLegality(Location loc)
	{
		// TODO
		return true;
	}
}
