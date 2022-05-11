using System;

public class Triangle: Shape
{
    public double a { get; set; }
    public double b { get; set; }
    public double c { get; set; }

    public Triangle(double a, double b, double c): base()
    {
        this.a = a;
        this.b = b;
        this.c = c;

        this.name = "Triangle";
        double semiperimeter = (a + b + c) / 2;
        this.setArea(Math.Sqrt(semiperimeter * (semiperimeter - a) * (semiperimeter - b) * (semiperimeter - c)));
        this.setPerimeter(a + b + c);
    }

    public override string getFullName()
    {
        return base.getFullName() + " " + typeOfTriangle();
    }

    private string typeOfTriangle()
    {
        string type;
        if (a == b && b == c)
        {
            type = "equilateral";
        }
        else if (a == b || a == c || b == c)
        {
            type = "isosceles";
        }
        else
        {
            type = "scalene";
        }
        return type;
    }
}