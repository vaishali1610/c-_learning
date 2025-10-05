using System;
using System.Threading;
//class Program
//{
//    static void PrintNumbers(string threadName)
//    {
//        for (int i = 1; i <= 5; i++)
//        {
//            Console.WriteLine($"{threadName}: {i}");
//            Thread.Sleep(500);
//        }
//    }
//    static void Main()
//    {
//        Thread thread1 = new Thread(() => PrintNumbers("Thread 1"));
//        Thread thread2 = new Thread(() => PrintNumbers("Thread 2"));
//        thread1.Start();
//        thread2.Start();
//        thread1.Join();
//        thread2.Join();
//        Console.WriteLine("All threads completed.");
//    }
//}
class Program
{
    static void PrintNumbers(string taskName)
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"{taskName}: {i}");
            Task.Delay(500).Wait();
        }
    }
    static void Main()
    {
        Task task1 = Task.Run(() => PrintNumbers("Task 1"));
        Task task2 = Task.Run(() => PrintNumbers("Task 2"));
        Task.WaitAll(task1, task2);
        Console.WriteLine("All tasks completed.");
    }
}
