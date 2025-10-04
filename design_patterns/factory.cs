using System;
public class Shape
{
    public virtual void Draw()=>Console.WriteLine("Default Shape");
}
public class Circle : Shape
{
    public override void Draw()=>Console.WriteLine("Drawing a Circle");
}
public class Rectangle : Shape
{
    public override void Draw()=>Console.WriteLine("Drawing a Rectangle");
}
public static class ShapeFactory
{
    public static Shape getShape(string shape)
    {
        switch (shape.ToLower())
        {
            case "circle": return new Circle();
            case "rectangle": return new Rectangle();
            default: return null;
        }
    }
}
class Program {
    static void Main(string[] args)
    {
        Shape s1 = ShapeFactory.getShape("circle");
        s1.Draw();
        Shape s2 = ShapeFactory.getShape("Rectangle");
        s2.Draw();
    }
}

