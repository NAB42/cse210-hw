using System.Transactions;

class Circle
{
    // Attributes 
    private double _radius;

    // Constructors
    public Circle()
    {
        this._radius=1.0;
    }
    public Circle(double radius)
    {
        this._radius=radius;
    }
    
    // Methods
    public void SetRadius(double radius)
    {
        this._radius=radius;
    }
    public double GetArea()
    {
        return Math.PI*(this._radius*this._radius);
    }
    public double GetCircumference()
    {
        return 2*Math.PI*_radius;
    }
    public double GetDiameter()
    {
        return this._radius*2;
    }
} 