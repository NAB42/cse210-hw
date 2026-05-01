// The Job class allows for the instantiation of objects that represent a person's job.

using System;
public class Job
{
    // Fields
    private string _company;
    private string _jobTitle;
    private int _startYear;
    private int _endYear;

    // Constructors
    public Job()
    {
        this._company = "Apple";
        this._jobTitle = "CEO";
        this._startYear = 2011;
        this._endYear = 2026;
    }
    public Job(string company,string jobTitle,int startYear,int endYear)
    {
        this._company = company;
        this._jobTitle = jobTitle;
        this._startYear = startYear;
        this._endYear = endYear;
    }
    public Job(string company,string jobTitle,int startYear)
    {
        this._company = company;
        this._jobTitle = jobTitle;
        this._startYear = startYear;
        this._endYear = DateTime.Now.Year;
    }

    // Methods
    public void Display()
    {
        // Displays the fields of the object in a neat way
        Console.WriteLine($"{this._jobTitle} ({this._company}) {this._startYear}-{this._endYear}");
    }
}