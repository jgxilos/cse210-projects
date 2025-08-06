using System;

public abstract class Shape
{
    private string _color;

    // Constructor to initialize the color
    public Shape(string color)
    {
        _color = color;
    }

    // Getter for the color
    public string GetColor()
    {
        return _color;
    }

    // Setter for the color
    public void SetColor(string color)
    {
        _color = color;
    }

    // Abstract method that must be implemented by derived classes
    public abstract double GetArea();
}