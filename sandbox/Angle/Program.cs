public class Program
{
    public static void Main(string[] args)
    {
        Angle a = new Angle(10);
        a.SetRadians(11);
        Console.WriteLine(a.GetRadians());
    }
}
