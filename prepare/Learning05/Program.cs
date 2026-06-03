using System;

class Program
{
    static void Main(string[] args)
    {
		List<Shape> s = new List<Shape>();
		s.Add(new Rectangle(5.7,4.3));
		s.Add(new Square(7.7));
		s.Add(new Circle(13f));
		foreach(Shape shapes in s)
		{
			Console.WriteLine(shapes.GetArea());
		}
    }
}
