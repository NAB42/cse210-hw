public class Rook : Piece 
{
	
	public Rook(bool side)
	{
		this.SetSide(side);
		this.SetLocation(new Location("A0"));

	}
	public override void Move(Location l)
	{
		// TODO
	}
	public override bool CheckLegality(Location l)
	{
		return true;
	}
	public override string ToString()
	{
		return GetSide() ? "♜" : "♖";
	}
}
