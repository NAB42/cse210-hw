using System;

class Program
{
    static void Main(string[] args)
    {
        int x;
        int y;
        Console.Write("Enter x: ");
        x = int.Parse(Console.ReadLine());
        Console.Write("Enter y: ");
        y = int.Parse(Console.ReadLine());
        for (int i = 0; i < y; i++)
        {
            for(int j = 0; j < x; j++)
            {
                Console.Write(i + " " + j + ", ");
            }
            Console.WriteLine();
        }
    }
}