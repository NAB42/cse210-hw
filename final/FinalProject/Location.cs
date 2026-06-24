public class Location
{
	private char _letter;
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
		return $"{_letter}{_number}";
	}
	public int GetNum()
	{
		return _number;
	}

}
