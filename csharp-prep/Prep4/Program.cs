using System;
/* Prep 4 - Lists
 * Alright, so the purpose of this program is so that I can become more familiar with Lists.
 * Basically it takes a list of numbers inputted by the user until a 0 is entered. Then it 
 * makes a sum of the numbers and an average of them, the largest and smallest numbers, and 
 * a sorted list.
 */
class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int current = 0;
        do
        {
            Console.Write("Enter a number: ");
            current = int.Parse(Console.ReadLine());
            numbers.Add(current);
        }while(current != 0);
        int sum = 0;
        foreach (int num in numbers){ 
            Console.Write(num + ", ");
            sum += num;
        }
        double avg = (double)sum/(double)numbers.Count()-1;
        Console.WriteLine("Sum is " + sum);
        Console.WriteLine("Avg is " + avg);
    }
}