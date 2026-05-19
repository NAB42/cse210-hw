using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment math = new MathAssignment("Jeff Bridges","Algebra",7.3,"18-20");
        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());
        Console.WriteLine();
        WritingAssignment write = new WritingAssignment("George Orwell","Persuasive Writing","1984");
        Console.WriteLine(write.GetSummary());
        Console.WriteLine(write.GetWritingInformation());
    }
}