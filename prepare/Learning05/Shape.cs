public abstract class Shape
{
	/* Attributes */
	private string _color;

	/* Methods */
	public string GetColor()
	{
		return _color;
	}
	public void SetColor(string color)
	{
		_color = color;
	}

	public abstract double GetArea();
}
