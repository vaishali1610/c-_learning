using System;
using System.Collections.Generic;
using System.Linq;
class Repository<T> where T : class
{
    private List<T> items = new List<T>();
    public void Add(T item)
    {
        items.Add(item);
        Console.WriteLine("Item added.");
    }
    public void Update(T oldItem, T newItem)
    {
        int index = -1;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == oldItem)
            {
                index = i;
                break;
            }
        }
        if (index >= 0)
        {
            items[index] = newItem;
            Console.WriteLine("Item updated.");
        }
        else
        {
            Console.WriteLine("Item not found.");
        }
    }
    public void Delete(T item)
    {
        bool removed = false;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == item)
            {
                items.RemoveAt(i);
                removed = true;
                break;
            }
        }
        if (removed)
            Console.WriteLine("Item deleted.");
        else
            Console.WriteLine("Item not found.");
    }
    public List<T> GetAll()
    {
        List<T> copy = new List<T>();
        foreach (T item in items)
            copy.Add(item);
        return copy;
    }
}
class Product
{
    public string Name { get; set; }
    public override string ToString() => Name;
}
class Program
{
    static void Main()
    {
        Repository<Product> repo = new Repository<Product>();
        Product p1 = new Product { Name = "Laptop" };
        Product p2 = new Product { Name = "Phone" };
        repo.Add(p1);
        repo.Add(p2);
        foreach (var item in repo.GetAll())
            Console.WriteLine(item);
        Product pUpdated = new Product { Name = "Gaming Laptop" };
        repo.Update(p1, pUpdated);
        Console.WriteLine("After update:");
        foreach (var item in repo.GetAll())
            Console.WriteLine(item);
        repo.Delete(p2);
        Console.WriteLine("After delete:");
        foreach (var item in repo.GetAll())
            Console.WriteLine(item);
    }
}


class Numbers
{
    public IEnumerable<int> GetEvenNumbers(int n)
    {
        for (int i = 2; i <= n; i += 2)
        {
            yield return i;  // produce one number at a time
        }
    }
}
class Program
{
    static void Main()
    {
        Numbers numbers = new Numbers();

        foreach (var num in numbers.GetEvenNumbers(10))
        {
            Console.WriteLine(num);
        }
    }
}
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public int Salary { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
List<Employee> employees = new List<Employee>()
        {
 new Employee { Id = 1, Name = "Jai", Department = "HR", Salary = 50000 },
new Employee { Id = 2, Name = "Zambavan", Department = "IT", Salary = 60000 },
 new Employee { Id = 4, Name = "Joshika", Department = "Finance", Salary = 70000 },
        };
var query = (from e in employees where e.Salary > 50000 group e by e.Department into deptGroup  
 orderby deptGroup.Key select deptGroup).Take(3);  

foreach (var group in query)
  {
            Console.WriteLine($"Department: {group.Key}");
 foreach (var emp in group)
{
 Console.WriteLine($"   {emp.Name} - {emp.Department} - {emp.Salary}");
}
        }
    }
}