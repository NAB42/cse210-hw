class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hey");
        Circle c = new Circle(17);
        Console.WriteLine(c.GetArea());
        Cylinder cyl = new Cylinder(c,10);
        Console.WriteLine(cyl.GetVolume());
    }
}