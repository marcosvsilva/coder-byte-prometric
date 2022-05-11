using System;

public class Shape: IComparable<Shape>
{
    private double parea;
    private double pperimeter;

    public double area { get => parea; }
    public double perimeter { get => pperimeter; }

    public string name { get; set; }

    public Shape()
    {
        this.name = "";
        this.parea = 0.0;
        this.pperimeter = 0.0;
    }

    public void setArea(double area)
    {
        this.parea = area;
    }

    public void setPerimeter(double perimeter)
    {
        this.pperimeter = perimeter;
    }

    public string printArea()
    {
        if (area > 0)
        {
            return $"Area form is {parea}";
        }
        else
        {
            return "Area is invalid"; ;
        }
    }

    public string printPerimeter()
    {
        if (perimeter > 0)
        {
            return $"Perimeter form is {pperimeter}";
        }
        else
        {
            return "Perimeter is invalid";
        }
    }

    public virtual string getFullName()
    {
        return name;
    }

    public int CompareTo(Shape other)
    {
        // Compares Area and Perimeter.
        if (this.area.CompareTo(other.area) != 0)
        {
            return this.area.CompareTo(other.area);
        }
        else if (this.perimeter.CompareTo(other.perimeter) != 0)
        {
            return this.perimeter.CompareTo(other.perimeter);
        }
        else
        {
            return 0;
        }
    }
}