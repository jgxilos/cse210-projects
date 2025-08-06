using System;

public class Circle : Shape
{
    private double _radius;

    // Constructor to initialize the circle with color and radius
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // Override the GetArea method for circles
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}