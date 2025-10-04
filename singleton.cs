using System;
using System.Threading;
using System.Threading.Tasks;
class Singleton
{
    private static Singleton instance;
    private Singleton()
    {
        Console.WriteLine("Singleton instance created.");
    }
    public static Singleton GetInstance()
    {
        if (instance == null)
        {
            instance = new Singleton();
        }
        return instance;
    }
    public void ShowMessage()
    {
        Console.WriteLine("Hello from Singleton!");
    }
}
class Program
{
    static void Main()
    {
        Singleton s1 = Singleton.GetInstance();
        Singleton s2 = Singleton.GetInstance();
        s1.ShowMessage();
        s2.ShowMessage();
        Console.WriteLine(object.ReferenceEquals(s1, s2)); // True, both are same instance
    }
}


class Logger
{
    private static Logger instance;
    private static readonly object lockObj = new object();
    private Logger()
    {
        Console.WriteLine("Logger instance created.");
    }
    public static Logger GetInstance()
    {
        if (instance == null)
        {
            lock (lockObj) // Only one thread can enter here at a time
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
            }
        }
        return instance;
    }
    public void Log(string message)
    {
        Console.WriteLine($"Log: {message}");
    }
}

class Program
{
    static void Main()
    {
        Logger logger1 = Logger.GetInstance();
        Logger logger2 = Logger.GetInstance();
        logger1.Log("First message");
        logger2.Log("Second message");
        Console.WriteLine(object.ReferenceEquals(logger1, logger2)); // True
    }
}

class Logger
{
    private static Logger instance;
    private static readonly object lockObj = new object();
    private Logger()
    {
        Console.WriteLine("Logger instance created.");
    }
    public static Logger GetInstance()
    {
        if (instance == null)
        {
            lock (lockObj)
            {
                if (instance == null)
                    instance = new Logger();
            }
        }
        return instance;
    }

    public void Log(string message)
    {
        Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] {message}");
    }
}

class Program
{
    static void Main()
    {
        Thread[] threads = new Thread[5]; //creating an array of threads
        for (int i = 0; i < 5; i++)
        {
            int threadNum = i + 1;
            threads[i] = new Thread(() =>
            {
                Logger logger = Logger.GetInstance();
                logger.Log($"Message from thread {threadNum}");
            });
            threads[i].Start(); //thread starts running
        }
        // Wait for all threads to finish
        foreach (var t in threads)
            t.Join();
        Console.WriteLine(object.ReferenceEquals(threads[1], threads[2]));
    }
}
class Logger
{
    private static Logger instance;
    private static readonly object lockObj = new object();
    private Logger()
    {
        Console.WriteLine("Logger instance created.");
    }
    public static Logger GetInstance()
    {
        if (instance == null)
        {
            lock (lockObj)
            {
                if (instance == null)
                    instance = new Logger();
            }
        }
        return instance;
    }
    public void Log(string message)
    {
        Console.WriteLine($"[{Task.CurrentId}] {message}");
    }
}
class Program
{
    static void Main()
    {
        Task[] tasks = new Task[5];
        for (int i = 0; i < 5; i++)
        {
            int taskNum = i + 1;
            tasks[i] = Task.Run(() =>
            {
                Logger logger = Logger.GetInstance();
                logger.Log($"Message from task {taskNum}");
            });
        }
        Task.WaitAll(tasks);
    }
}