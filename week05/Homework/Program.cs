using System;

class Program
{
    static void Main(string[] args)
    {
        //  Base class test
        Assignment assignment = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(assignment.GetSummary()); // Output: Samuel Bennett - Multiplication

        // MathAssignment test
        MathAssignment math = new MathAssignment(
            "Roberto Rodriguez", 
            "Fractions", 
            "7.3", 
            "8-19"
        );
        Console.WriteLine(math.GetSummary()); // Output: Roberto Rodriguez - Fractions
        Console.WriteLine(math.GetHomeworkList()); // Output: Section 7.3 Problems 8-19

        // WritingAssignment test
        WritingAssignment writing = new WritingAssignment(
            "Mary Waters", 
            "European History", 
            "The Causes of World War II"
        );
        Console.WriteLine(writing.GetSummary()); // Output: Mary Waters - European History
        Console.WriteLine(writing.GetWritingInformation()); // Output: The Causes of World War II by Mary Waters
    }
}