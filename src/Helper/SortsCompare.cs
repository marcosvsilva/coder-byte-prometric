using System.Collections.Generic;

public class SortByArea : Comparer<Shape>
{
    // Compare by Area.
    public override int Compare(Shape x, Shape y)
    {
        if (x.area.CompareTo(y.area) != 0)
        {
            return x.area.CompareTo(y.area);
        }
        else
        {
            return 0;
        }
    }
}

public class SortByPerimeter : Comparer<Shape>
{
    // Compare by Perimeter.
    public override int Compare(Shape x, Shape y)
    {
        if (x.perimeter.CompareTo(y.perimeter) != 0)
        {
            return x.perimeter.CompareTo(y.perimeter);
        }
        else
        {
            return 0;
        }
    }
}