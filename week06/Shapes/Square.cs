using System;

public class Square : Shape
{
    private double _side;

    // Constructor to initialize the square with color and side length
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    // Override the GetArea method for squares
    public override double GetArea()
    {
        return _side * _side;
    }
}