using System;

public class Circle : Shape
{
    private static double PI = 3.14;

    public double radius { get; set; }

    public Circle(double radius) : base()
    {
        this.radius = radius;

        base.name = "Circle";
        base.setArea(PI * radius * radius);
        base.setPerimeter(2 * PI * radius);
    }

    public override string getFullName()
    {
        return base.getFullName();
    }

}