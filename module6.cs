using System;

public class InvalidSalaryException : Exception
{
    public InvalidSalaryException(string message) : base(message)
    { }
}

class Program
{
    static void CheckSalary(int salary)
    {
        if (salary < 0)
        {
            throw new InvalidSalaryException("Salary cannot be negative!");
        }
        Console.WriteLine($"Salary is valid: {salary}");
    }
    static void Main()
    {
        try
        {
            Console.WriteLine("Checking salary...");
            CheckSalary(-5000); 
        }
        catch (InvalidSalaryException ex)
        {
            Console.WriteLine($"Custom Exception Caught: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General Exception: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Finally block executed");
        }
    }
}
