using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
class Program
{
    static async Task<List<string>> FetchEmployeesAsync()
    {
        Console.WriteLine("Fetching employees...");
        await Task.Delay(5000); 
        return new List<string> { "Jai", "subha", "Joshika" };
    }

    static async Task Main(string[] args)
    {
        Console.WriteLine("Program started.");
        List<string> employees = await FetchEmployeesAsync();
        Console.WriteLine("Employees fetched:");
        foreach (var emp in employees)
        {
            Console.WriteLine(emp);
        }

        Console.WriteLine("Program ended.");
    }
}
