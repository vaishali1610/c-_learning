using System;

//class Singleton
//{
//    private static Singleton instance;
//    private Singleton()
//    {
//        Console.WriteLine("Singleton instance created.");
//    }
//    public static Singleton GetInstance()
//    {
//        if (instance == null)
//        {
//            instance = new Singleton(); 
//        }
//        return instance;
//    }
//    public void ShowMessage()
//    {
//        Console.WriteLine("Hello from Singleton!");
//    }
//}
//class Program
//{
//    static void Main()
//    {
//        Singleton s1 = Singleton.GetInstance();
//        Singleton s2 = Singleton.GetInstance();
//        s1.ShowMessage();
//        s2.ShowMessage();
//        Console.WriteLine(object.ReferenceEquals(s1, s2)); // True, both are same instance
//    }
//}


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
