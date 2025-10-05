using System;
public abstract class CatBehavior
{
    public abstract void Act();
}
public class MeowBehavior : CatBehavior
{
    public override void Act()
    {
        Console.WriteLine("The cat meows");
    }
}
public class PurrBehavior : CatBehavior
{
    public override void Act()
    {
        Console.WriteLine("The cat purrs");
    }
}
public class SleepBehavior : CatBehavior
{
    public override void Act()
    {
        Console.WriteLine("The cat sleeps");
    }
}
public class Cat
{
    private CatBehavior behavior; 
    public Cat(CatBehavior behavior)
    {
        this.behavior = behavior; 
    }
    public void PerformBehavior()
    {
        behavior.Act();
    }
    public void SetBehavior(CatBehavior newbehavior)
    {
        this.behavior = newbehavior;
    }
}
class Program
{
    static void Main()
    {
        Cat kitty = new Cat(new MeowBehavior());
        kitty.PerformBehavior();  
        kitty.SetBehavior(new PurrBehavior());
        kitty.PerformBehavior();  
        kitty.SetBehavior(new SleepBehavior());
        kitty.PerformBehavior();  
    }
}
