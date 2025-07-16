using System;

public class Fraction
{
    // Private attributes for numerator and denominator
    private int _top;
    private int _bottom;

    // Constructor without parameters (initializes to 1/1)
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor with integer (converts to fraction over 1)
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    // Constructor with explicit numerator and denominator
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getter and Setter for the numerator
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    // Getter and Setter for the denominator
    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // Returns the string representation of the fraction
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Returns the decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}