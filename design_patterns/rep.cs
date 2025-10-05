using System;
using System.Collections.Generic;
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
}
public class Repository<T> where T : class
{
    private List<T> _data = new List<T>();
    public void Add(T entity) => _data.Add(entity);
    public void Remove(T entity) => _data.Remove(entity);
    public IEnumerable<T> GetAll() => _data;
    public void Clear() => _data.Clear();
}
public class UnitOfWork
{
    public Repository<Employee> Employees { get; } = new Repository<Employee>();
 public void Commit()=> Console.WriteLine("\ncommitted successfully!");
    public void Rollback()
    {
        Employees.Clear();
        Console.WriteLine("\n rolled back!");
    }
}
class Program
{
    static void Main()
    {
        var unitOfWork = new UnitOfWork();
        unitOfWork.Employees.Add(new Employee { Id = 1, Name = "Jai", Department = "CEO" });
        unitOfWork.Employees.Add(new Employee { Id = 2, Name = "Vaish", Department = "Web development" });
        unitOfWork.Employees.Add(new Employee { Id = 3, Name = "Joshi", Department = "App development" });
        Console.WriteLine("Employees before Commit:");
        foreach (var emp in unitOfWork.Employees.GetAll())
        {
            Console.WriteLine($"{emp.Id}: {emp.Name} ({emp.Department})");
        }
        unitOfWork.Commit();
        unitOfWork.Rollback();
        Console.WriteLine("\nEmployees after Rollback:");
        foreach (var emp in unitOfWork.Employees.GetAll())
        {
            Console.WriteLine($"{emp.Id}: {emp.Name} ({emp.Department})");
        }
    }
}
