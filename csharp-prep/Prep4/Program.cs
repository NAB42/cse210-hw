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
        Console.WriteLine("Enter a series of numbers, type 0 when finished");

        // The loop to create the List of numbers
        do
        {
            Console.Write("Enter a number: ");
            current = int.Parse(Console.ReadLine());
            numbers.Add(current);
        }while(current != 0);

        int sum = 0;
        int biggest=0;
        int smallest = numbers[0];

        // Calculate the sum, average, biggest and smallest numbers.
        foreach (int num in numbers){ 
            sum += num;
            if(num > biggest)
            {
                biggest = num;
            }
            if(num < smallest && num != 0)
            {
                smallest = num;
            }
        }
        double avg = (double)sum/(double)numbers.Count()-1;

        // Print out all the results
        Console.WriteLine("Sum is " + sum);
        Console.WriteLine("Avg is " + avg);
        Console.WriteLine("The biggest number is " + biggest);
        Console.WriteLine("The smallest number is " + smallest);

        //Sort the list.
        numbers.Sort();
        Console.WriteLine("The sorted list is");
        foreach (int num in numbers){
            Console.WriteLine(num);
        }
    }
}