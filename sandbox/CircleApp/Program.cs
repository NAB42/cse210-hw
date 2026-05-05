class Program
{
    public static void Main(string[] args)
    {
        // This is a test comment for git
        Console.WriteLine("Hello");
        Circle c = new Circle(17);
        Console.WriteLine(c.GetArea());
        Cylinder cyl = new Cylinder(c,10);
        Console.WriteLine(cyl.GetVolume());
    }
}