/* 2026.05.15 Nathan Boulton; */
using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f = new Fraction();
        Random rnd = new Random();
        // Makes 20 random fractions and displays them
        for(int i=1;i<=20;i++){
            f.SetNumerator(rnd.Next(1,20));
            f.SetDenominator(rnd.Next(1,20));
            Console.WriteLine($"Fraction {i}:");
            Console.WriteLine(f.ProperFraction());
            Console.WriteLine(f.ImproperFraction());
            Console.WriteLine(f.GetDecimal());
            Console.WriteLine();
        }
    }
}