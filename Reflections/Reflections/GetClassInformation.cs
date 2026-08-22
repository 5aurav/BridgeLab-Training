using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Reflections
{

public class GetClassInformation
    {
    public static void Run()
    {
        Console.Write("Enter class name: ");
        string className = Console.ReadLine();

        Assembly assembly = Assembly.GetExecutingAssembly();

        Type type = assembly.GetTypes()
            .FirstOrDefault(t =>
                t.Name.Equals(className, StringComparison.OrdinalIgnoreCase));

        if (type == null)
        {
            Console.WriteLine("Class not found.");
            return;
        }

        Console.WriteLine($"\nClass: {type.Name}");

        Console.WriteLine("\nConstructors:");
        foreach (ConstructorInfo constructor in type.GetConstructors(
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.Instance |
            BindingFlags.Static))
        {
            Console.WriteLine(constructor);
        }

        Console.WriteLine("\nMethods:");
        foreach (MethodInfo method in type.GetMethods(
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.DeclaredOnly))
        {
            Console.WriteLine(method);
        }

        Console.WriteLine("\nFields:");
        foreach (FieldInfo field in type.GetFields(
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.DeclaredOnly))
        {
            Console.WriteLine(field);
        }
    }
}

public class ReflectionStudent
{
    private int age;

    public string Name { get; set; }

    public ReflectionStudent()
    {
        Name = "Unknown";
    }

    public ReflectionStudent(string name)
    {
        Name = name;
    }

    public void Study()
    {
        Console.WriteLine("Student is studying.");
    }

    private void SecretMethod()
    {
        Console.WriteLine("Private method.");
    }
}
}
