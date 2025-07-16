using System;

class Program
{
    static void Main(string[] args)
    {
        // Create instances using all constructors
        Fraction f1 = new Fraction();              // 1/1
        Fraction f2 = new Fraction(5);            // 5/1
        Fraction f3 = new Fraction(3, 4);         // 3/4
        Fraction f4 = new Fraction(1, 3);         // 1/3

        // Mostrar resultados iniciales
        ShowFractionInfo(f1);
        ShowFractionInfo(f2);
        ShowFractionInfo(f3);
        ShowFractionInfo(f4);

        // Modify values using setters and display changes
        f1.SetTop(2);
        f1.SetBottom(5);
        Console.WriteLine("\nAfter modifying f1:");
        ShowFractionInfo(f1);

        f3.SetTop(7);
        f3.SetBottom(8);
        Console.WriteLine("\nAfter modifying f3:");
        ShowFractionInfo(f3);
    }

    // Auxiliary method for displaying fraction information
    private static void ShowFractionInfo(Fraction frac)
    {
        Console.WriteLine($"Fraction: {frac.GetFractionString()}");
        Console.WriteLine($"Decimal: {frac.GetDecimalValue():0.##########}");
    }
}