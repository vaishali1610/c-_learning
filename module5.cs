using System;
using System.Collections.Generic;

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
