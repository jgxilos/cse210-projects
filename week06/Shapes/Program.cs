using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold shapes
        List<Shape> shapes = new List<Shape>();

        // Create instances of different shapes
        Square square = new Square("Red", 3);
        Rectangle rectangle = new Rectangle("Blue", 4, 5);
        Circle circle = new Circle("Green", 6);

        // Add shapes to the list
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        // Iterate through the list and display the color and area of each shape
        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area:F2}.");
        }
    }
}