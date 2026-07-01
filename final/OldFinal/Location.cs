public class Location
{
	private int _letter;
	private int _number;

	public Location(string location)
	{
		_letter = location[0];
		_number = location[1]-48;
	}
	public Location(char letter,int number)
	{
		_letter = letter;
		_number = number;
	}

	public override string ToString()
	{
		return $"{(char)_letter}{_number + 1}";
	}
	public int GetNum()
	{
		return _number;
	}
	public int GetLetter()
	{
		return _letter;
	}
	public void SetLocation(int l,int n)
	{
		_letter = l;
		_number = n;
	}

}
