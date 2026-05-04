class Cylinder
{
    private Circle _circle;
    private double _height;

    public Cylinder()
    {
        this._circle=new Circle();
        this._height=1.0;
    }
    public Cylinder(Circle circle,double height)
    {
        this._circle=circle;
        this._height=height;
    }

    public double GetVolume()
    {
        return this._circle.GetArea()*this._height;
    }
}