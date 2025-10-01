using System;
//---------------------constructor chaining
class Student

{
    private string name;
    private int age;
    private string grade;
    public string SchoolName = "Bright Future School";
    public readonly DateTime AdmissionDate;
    public string Name => name; //property
    public Student()
    {
        name = "Unknown";
        age = 0;
        grade = "None";
        AdmissionDate = DateTime.Now;
        Console.WriteLine("Default constructor");
    }
    public Student(string name, int age, string grade) : this()
    {
        this.name = name;
        this.age = age;
        this.grade = grade;
        Console.WriteLine("Parameterized constructor");
    }
    public Student(string name) : this(name, 18, "A")
    {
        Console.WriteLine("Single parameter constructor");
    }
    public void Display() => Console.WriteLine($"{name}, {age}, {grade}, Admission: {AdmissionDate}, School: {SchoolName}");
    public void info(string name) => Console.Write(name);
    public void info(string name, int age) => Console.WriteLine(name + " " + age);
    public void info(string name, int age, string grade) => Console.WriteLine(grade);

}

class Program
{
    static void Main()
    {
        Student s1 = new Student("Vaishali");
        s1.Display();
        //s1.AdmissionDate = DateTime.Now;
        s1.SchoolName = "school";//if not const
        s1.SchoolName = "New School";
        s1.Display();
        s1.info("vaishh");
        s1.info("vaish", 21);

    }
}
//--------------partial methods------------------------
partial class Student
{
    private string names = "Vaishali";
    private string age;
    public string Names => names;
    partial void details() => Console.WriteLine(Names);
    public string Name
    {
        get
        {
            details();
            return names;
        }
    }
    public void callDetails() => details();
}
partial class Student
{
    partial void details();
}
class Program
{
    static void Main(string[] args)
    {
        Student s = new Student();
        // s.details(); //should not call it like this
        s.callDetails();
    }
}
//--------------------------access modifiers------------

class Person
{
    public string Name;           //  Accessible anywhere 
    private int age;              //  Accessible only inside Person 
    protected string country;     //  Accessible in derived class 
    internal string School;       //  Accessible within same assembly/project 
    public Person(string name, int age, string country, string school)
    {
        this.Name = name;
        this.age = age;
        this.country = country;
        this.School = school;
    }
    private void ShowAge() => Console.WriteLine($"Age: {age}");
    public void DisplayAge() => ShowAge(); //  calling private method internally 
    protected void ShowCountry() => Console.WriteLine($"Country: {country}");
    internal void ShowSchool() => Console.WriteLine($"School: {School}");

    }
class Student : Person
{
    public Student(string name, int age, string country, string school)
          : base(name, age, country, school) { }
    public void DisplayInfo()

    {
        Console.WriteLine($"Name: {Name}");
        // Console.WriteLine($"Age: {age}"); //  private  not accessible 
        Console.WriteLine($"Country: {country}"); // protected  accessible in derived class 
        Console.WriteLine($"School: {School}");  // internal  accessible in same assembly 
        ShowCountry();
        ShowSchool();
    }
}
class Program
{
    static void Main()
    {
        Student s = new Student("Vaishali", 21, "India", "Bright School");
        Console.WriteLine($"Name: {s.Name}");
        s.DisplayAge();
        // s.ShowCountry();                     //  protected  not accessible from object 
        s.ShowSchool();                         // internal - accessible in same assembly 
        s.DisplayInfo();
    }
}