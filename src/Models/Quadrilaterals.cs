using System;

public class Quadrilaterals : Shape
{
    public double swidth { get; set; }
    public double length { get; set; }

    public Quadrilaterals(double width, double length) : base()
    {
        this.swidth = width;
        this.length = length;

        this.name = "Quadrilaterals";
        this.setArea(width * length);
        this.setPerimeter((width + length) * 2);
    }

    public override string getFullName()
    {
        return getSpecificName();
    }

    public string getSpecificName()
    {
        if (swidth == length)
        {
            return "Square";
        }
        else
        {
            return "Rectangle";
        }
    }
}