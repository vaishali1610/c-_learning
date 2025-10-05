using System;
using System.Collections.Generic;
public interface IObserver //like delegate
{
    void Update(string news);
}
public class NewsAgency
{
    private List<IObserver> observers = new List<IObserver>();
    private string latestNews;
    public void AddObserver(IObserver observer) => observers.Add(observer);
    public void RemoveObserver(IObserver observer) => observers.Remove(observer);
    public void SetNews(string news) // the event
    {
        latestNews = news;
        NotifyObservers();
    }
    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(latestNews);
        }
    }
}
public class Reader : IObserver
{
    private string name;
    public Reader(string name)
    {
        this.name = name;
    }
    public void Update(string news)
    {
        Console.WriteLine($"{name} received news: {news}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        NewsAgency agency = new NewsAgency();
        Reader r1 = new Reader("Vicky");
        Reader r2 = new Reader("Tom");
        agency.AddObserver(r1);
        agency.AddObserver(r2);
        agency.SetNews("C# 13 Released!");
        agency.SetNews("Observer Pattern Explained!");
    }
}

