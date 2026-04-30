using System;
// This is a super redundant display of functions and how they work.
// The program takes a user's name, favorite number, and birth year, and then calculates
// accordingly. 
class Program
{
    static void DisplayProgram()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        Console.Write("Enter name: ");
        return Console.ReadLine();
    }
    static int PromptUserNumber()
    {
        Console.Write("Enter favorite number: ");
        return int.Parse(Console.ReadLine());
    }
    static void PromptUserBirthYear(out int year)
    {
        Console.Write("Enter birth year: ");
        year = int.Parse(Console.ReadLine());
    }
    static int Square(int x)
    {
        return x*x; 
    }
    static void DisplayResult(string name,int number, int year)
    {
        Console.WriteLine(name + ", the square of your number is " + Square(number));
        Console.WriteLine(name + ", you will turn " + (DateTime.Now.Year - year) + " years old this year.");
    }

    static void Main(string[] args)
    {
        int userBirthYear;
        DisplayProgram();
        string username = PromptUserName();
        int number = PromptUserNumber();
        PromptUserBirthYear(out userBirthYear);
        DisplayResult(username,number,userBirthYear);


    }
}