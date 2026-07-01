public class Queen : Piece
{
	public Queen(Location location,bool side)
	{
		this.SetLocation(location);
		this.SetSide(side);
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
