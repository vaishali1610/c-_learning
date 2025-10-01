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
