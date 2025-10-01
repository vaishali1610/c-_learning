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
-------------Single - Inheritance
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
//-----------------hybrid inheritance--------------
interface Fruit {
    public void print() ;
}
interface Ibanana { public void printBanana() ; }
class Apple : Fruit
{
    public void print() => Console.WriteLine("apple");
}
class Banana: Ibanana {
    public void printBanana() => Console.WriteLine("banana");
}
class MilkShake: Apple, Ibanana
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
       mk.printBanana() ;
    }
}
