using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f = new Fraction();
        Console.Write("Numerator: ");
        f.SetNumerator(int.Parse(Console.ReadLine()));
        Console.Write("Denominator: ");
        f.SetDenominator(int.Parse(Console.ReadLine()));
        Console.WriteLine(f.ProperFraction());
        Console.WriteLine(f.ImproperFraction());
    }
}