using System;
////---------------delegate-------------
namespace DelegateDemo
{
    public delegate double MathOperation(double a, double b);

    class Program
    {
        static double Add(double x, double y) => x + y;
        static double Subtract(double x, double y) => x - y;
        static double Multiply(double x, double y) => x * y;
        static double Divide(double x, double y) => x / y;

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
namespace AlarmClock
{
    public delegate void AlarmDelegate(string alarm);
    class Alarm // Publisher
    {
        public event AlarmDelegate Ring;
        public void StartAlarm(string time)
        {
            Console.WriteLine($"Time: {time}");
            OnRing(time);
        }
        protected virtual void OnRing(string time)
        {
            Ring?.Invoke(time);
        }
    }
    public class Person // Subscriber
    {
        public string Name { get; set; }
        public Person(string name)
        {
            Name = name;
        }
        public void WakeUp(string time)
        {
            Console.WriteLine($"{Name} wakes up! Alarm rang at {time}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Alarm myAlarm = new Alarm();
            Person alice = new Person("Jaisree");
            Person bob = new Person("Zambavan");
            myAlarm.Ring += alice.WakeUp;
            myAlarm.Ring += bob.WakeUp;
            myAlarm.StartAlarm("7:00 AM");
        }
    }
}
//----------------overriding in delegates
public delegate void Overriding(string method);
class DelegateOver
{
    static void MethodA(string a) => Console.WriteLine("MethodA"+ a);
    static void MethodB(string b) => Console.WriteLine("MethodB"+ b);
    static void Main(string[] args)
    {
    Overriding d;
        d = MethodA;
        d("Hello");
        d = MethodB;
        d("Hello"); 
        d += MethodA;
        d("Hello"); 
        d -= MethodB;
        d("Hello"); 
    }
}
