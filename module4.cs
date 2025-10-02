using System;
//---------------delegate-------------


namespace DelegateDemo
{
    public delegate double MathOperation(double a, double b);

    class Program
    {
        static double Add(double x, double y) => x + y;
        static double Subtract(double x, double y) => x - y;
        static double Multiply(double x, double y) => x * y;
        static double Divide(double x, double y) => x/y;

        static void Main(string[] args)
        {
// we can create multiple instances also
            MathOperation op;
            op = Add;
            Console.WriteLine($"Add: {op(10, 5)}");   
            op = Subtract;
            Console.WriteLine($"Subtract: {op(10, 5)}"); 
            op = Multiply;
            Console.WriteLine($"Multiply: {op(10, 5)}"); 
            op = Divide;
            Console.WriteLine($"Divide: {op(10, 5)}");   
        }
    }
}
