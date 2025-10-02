using System;
class BankAccount

{
    private decimal balance;
    public decimal Balance => balance;
    public BankAccount(decimal initialBalance)
    {
        if (initialBalance < 0)
        {
            Console.WriteLine("Insufficient balance");
        }
        balance = initialBalance;

    }
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Deposit amount must be positive.");

        }
        balance += amount;
        Console.WriteLine($"Deposited {amount.ToString("C")}. New balance: {balance:C}");
    }
    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Withdrawal amount must be positive.");
            return;

        }
        if (amount > balance)

        {
            Console.WriteLine("Insufficient balance.");
            return;

            balance -= amount;
            Console.WriteLine($"Withdrew {amount:C}. New balance: {balance:C}");

        }

    }

}
class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount(500); // initial balance 
        Console.WriteLine($"Initial Balance: {account.Balance:C}");
        account.Deposit(200);
        account.Withdraw(100);
        // account.balance = 10000; //   Cannot access private field directly 

    }
}
//-------------Single - Inheritance
class Vehicle
{
    public void Start() => Console.WriteLine("Vehicle starting...");

}

class Car : Vehicle
{
    public void Drive() => Console.WriteLine("Car driving...");
}
//----------multi-level Inheritance
class Benz : Car
{
    public void Starting() => Console.WriteLine("Benz started");
}//hierarchical
class Bmw : Car
{
    public void bmw() => Console.WriteLine("Bmw strated");
}

class Program
{
    static void Main(string[] args)
    {
        Car car = new Car();
        Benz benz = new Benz();
        Bmw bmw = new Bmw();
        bmw.bmw();
        car.Start();
        car.Drive();
        car.Starting(); //not allowed
        benz.Start();
        benz.Starting();
    }
}
////-----------------hybrid inheritance--------------
interface Fruit
{
    public void print();
}
interface Ibanana { public void printBanana(); }
class Apple : Fruit
{
    public void print() => Console.WriteLine("apple");
}
class Banana : Ibanana
{
    public void printBanana() => Console.WriteLine("banana");
}
class MilkShake : Apple, Ibanana
{
    private Ibanana banana;

    public MilkShake(Ibanana banana)
    {
        this.banana = banana;
    }

    public void printBanana()
    {
        banana.printBanana();
    }
}

class Program
{
    static void Main(string[] args)
    {
        MilkShake mk = new MilkShake(new Apple());
        mk.printBanana();
    }
    //}
    //-----------------method Overriding
    class Gadget
    {
        public virtual void print() => Console.WriteLine("Gadget");
    }
    class Phone : Gadget
    {
        public override void print() => Console.WriteLine("Phone");
    }
    class Samsung : Phone
    {
        public sealed override void print() => Console.WriteLine("samsung");
    }
    class Laptop : Samsung
    {
        public override void print() => Console.WriteLine("samsung lap");
    }
    class Program
    {
        static void Main(string[] args)
        {
            Phone phone = new Phone();
            Laptop laptop = new Laptop();
            Samsung samsung = new Samsung();
            laptop.print();
            phone.print();
            samsung.print();
        }
    }
    //------------------------abstraction-------------------
    abstract class Shape
    {
        public string Name { get; set; }
        abstract public double calculateArea();
        public void print() => Console.WriteLine("shape");
    }
    class Circle : Shape
    {
        public int Radius { get; set; }
        public Circle(int radius)
        {
            Radius = radius;
            Name = "circle";
        }
        public override double calculateArea()
        {
            Console.WriteLine(Name);
            return Radius * Radius * 3.14;
        }
    }
    class Rectangle : Shape
    {
        public int Length { get; set; }
        public Rectangle(int length)
        {
            Length = length;
            Name = "Rectangle";
        }
        public override double calculateArea()
        {
            Console.WriteLine(Name);
            return Length * 2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Circle c = new Circle(5);
            Console.WriteLine(c.calculateArea());
            Rectangle r = new Rectangle(5);
            Console.WriteLine(r.calculateArea());
        }
    }
---------------------interface------------------------------------
interface Shape
    {
        string Name { get; set; }
        double calculateArea();
        void print();
    }
    class Circle : Shape
    {
        public string Name { get; set; }
        public int Radius { get; set; }
        public Circle(int radius)
        {
            Radius = radius;
            Name = "circle";
        }
        public double calculateArea()
        {
            Console.WriteLine(Name);
            return Radius * Radius * 3.14;
        }
        public void print() => Console.Write("circle");
    }
    class Rectangle : Shape
    {
        public string Name { get; set; }
        public int Length { get; set; }
        public Rectangle(int length)
        {
            Length = length;
            Name = "Rectangle";
        }
        public double calculateArea()
        {
            Console.WriteLine(Name);
            return Length * 2;
        }
        public void print() => Console.WriteLine("rectangle");
    }
    class Program
    {
        static void Main(string[] args)
        {
            Circle c = new Circle(5);
            Console.WriteLine(c.calculateArea());
            Rectangle r = new Rectangle(5);
            Console.WriteLine(r.calculateArea());
        }
    }
    //----------------polymorphism 
    class Overloading
{ 
    public virtual void operate(int a,int b)=>Console.WriteLine(a+b);
    public void method() => Console.WriteLine("no parameters");
    public void method(int n) => Console.WriteLine(n);
    public void method(string name)=> Console.WriteLine(name);
    public void method(string name, int age)=> Console.WriteLine(name+" "+age);
}
class Overrides : Overloading
{
    public override void operate(int a,int b)=>Console.Write(a*b);
}
class Program
{
    static void Main(string[] args)
    {
        Overloading o = new Overloading();
        Overrides ov = new Overrides();
        o.operate(1, 2);
        ov.operate(1, 2);
        o.method();
        o.method("jaisree");
        o.method("subha", 22);
    }
}


