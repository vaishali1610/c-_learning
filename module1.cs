//#define DEBUG
// namespace----------------------------------------------------
using System;
namespace KennelApp
{
    class Dog
    {
        public void Bark()
        {
            Console.WriteLine("Kennel Dog Woof!");
        }
    }
}

namespace ZooApp
{
    class Dog
    {
        public void Bark()
        {
            Console.WriteLine("Zoo Dog Grrr!");
        }
    }
}
class Programming
{
    public static void Main()
    {
        KennelApp.Dog d1 = new KennelApp.Dog();
        d1.Bark();

        ZooApp.Dog d2 = new ZooApp.Dog();
        d2.Bark();
    }
}
//---------Preprocessor directive--------------

//class Program
//{
//    static void Main()
//    {
//#if DEBUG 
//        Console.WriteLine("Debug mode active!");
//#else
//        Console.WriteLine("No debug");

//#endif
//    }
//}
//--------------------value type------------------
//int a = 10;
//int b = a;  // copies the value
//b = 20;

//Console.WriteLine(a); // 10
//Console.WriteLine(b); // 20
//------------Reference type-----------
//class Person
//{
//    public string name;
//}

//class Programing
//{
//    static void Main()
//    {
//        Person p1 = new Person();
//        p1.name = "Person1";

//        Person p2 = p1;       // p2 points to the same object as p1
//        p2.name = "Person2";  // modifies the same object

//        Console.WriteLine(p1.name);  // Output: Person2
//    }
//}


