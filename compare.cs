using System;
using System.Collections.Generic;
class Employee : IComparable<Employee>
{
    public string Name { get; set; }
    public int Salary { get; set; }
    public int CompareTo(Employee other)
    {
        if (other == null) return 1;
        return this.Salary.CompareTo(other.Salary);
    }
    public override string ToString()
    {
        return $"{Name} - {Salary}";
    }
}
class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>()
        {
            new Employee { Name = "Jai", Salary = 50000 },
            new Employee { Name = "Zambavan", Salary = 60000 },
            new Employee { Name = "Joshika", Salary = 55000 }
        };
        Console.WriteLine("Before Sorting:");
        foreach (var emp in employees)
            Console.WriteLine(emp);
        employees.Sort();
        Console.WriteLine("\nAfter Sorting by Salary (Ascending):");
        foreach (var emp in employees)
            Console.WriteLine(emp);
    }
}
