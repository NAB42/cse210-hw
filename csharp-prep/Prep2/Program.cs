// The purpose of this program is to take an integer percentage grade,

using System;
class Program
{
    static void Main(string[] args)
    {  
        Console.Write("Enter your course percentage grade: ");
        string ans = Console.ReadLine();
        int pct = int.Parse(ans);
        string letterGrade;
        //Determines what letter to assign
        //Honestly a switch case would be better
        if (pct >= 90)
        {
            letterGrade = "A";
        }
        else if (pct >= 80)
        {
            letterGrade = "B";
        }
        else if (pct >= 70)
        {
            letterGrade = "C";
        }
        else if (pct >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        //Adds the +/- and worms out the exceptions
        if (!letterGrade.Equals("F"))
        {
            int finalNum = int.Parse(ans.Substring(ans.Length-1,ans.Length-1));
            if (finalNum >= 7)
            {
                letterGrade += "+";
            }
            else if (finalNum < 3)
            {
                letterGrade += "-";
            } 
            if (letterGrade.Equals("A+"))
            {
                letterGrade = "A";
            }
        }
        Console.WriteLine($"Your final grade is {letterGrade}");

    }
}