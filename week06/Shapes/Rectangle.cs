using System;

public class Rectangle : Shape
{
    private double _length;
    private double _width;

    // Constructor to initialize the rectangle with color, length, and width
    public Rectangle(string color, double length, double width) : base(color)
    {
        _length = length;
        _width = width;
    }

    // Override the GetArea method for rectangles
    public override double GetArea()
    {
        return _length * _width;
    }
}