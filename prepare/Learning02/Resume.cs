// The Resume class allows for the instantiation of an object that tracks a person's name and 
// job history. Pretty self-explanatory.
using System;
public class Resume
{
    // Fields
    private string _name;
    private List<Job> _jobs;

    // Constructors
    public Resume()
    {
        this._name = "Tim Cook";
        this._jobs = new List<Job>();
    }

    // Methods
    public void Display()
    {
        // Prints out the name of the person and the jobs they have had.
        Console.WriteLine("Name: " + this._name);
        Console.WriteLine("Jobs: ");
        foreach (Job job in this._jobs)
        {
            job.Display();
        }
    }
    public List<Job> Jobs()
    {
        return this._jobs;
    }
    public string Name()
    {
        return this._name;
    }
    public void AddJob(Job job)
    {
        this._jobs.Add(job);
    }
}