using System;

class Program
{
    static void Main(string[] args)
    {
        Job first = new Job("Broulims","Grocery Bagger",2009,2011);
        Job second = new Job("Microsoft","Software Engineer",2011,2017);
        Job third = new Job("Apple","Software Engineer",2017,2023);
        Job fourth = new Job("Canonical","Software Lead",2023);
        Resume frank = new Resume("Frank Walsh",new List<Job>{first,second,third,fourth});
        frank.Display();
    }
}