using System;
using System.Collections.Generic;

namespace NUnitPrograms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            Console.WriteLine($"10 + 5 = {calculator.Add(10, 5)}");
            Console.WriteLine($"10 - 5 = {calculator.Subtract(10, 5)}");
            Console.WriteLine($"10 * 5 = {calculator.Multiply(10, 5)}");
            Console.WriteLine($"10 / 5 = {calculator.Divide(10, 5)}");

            Console.WriteLine();

            StringUtils stringUtils = new StringUtils();

            Console.WriteLine($"Reverse of Hello: {stringUtils.Reverse("Hello")}");
            Console.WriteLine($"Is 'madam' Palindrome? {stringUtils.IsPalindrome("madam")}");
            Console.WriteLine($"Uppercase: {stringUtils.ToUpperCase("hello")}");

            Console.WriteLine();

            ListManager listManager = new ListManager();
            List<int> list = new List<int>();

            listManager.AddElement(list, 10);
            listManager.AddElement(list, 20);
            listManager.AddElement(list, 30);

            Console.WriteLine($"List Size: {listManager.GetSize(list)}");

            listManager.RemoveElement(list, 20);

            Console.WriteLine($"List Size After Removal: {listManager.GetSize(list)}");

            Console.WriteLine();

            MathOperations math = new MathOperations();

            Console.WriteLine($"20 / 5 = {math.Divide(20, 5)}");

            Console.WriteLine();

            DatabaseConnection db = new DatabaseConnection();

            db.Connect();
            Console.WriteLine($"Connected: {db.IsConnected}");

            db.Disconnect();
            Console.WriteLine($"Connected After Disconnect: {db.IsConnected}");

            Console.WriteLine();

            NumberChecker checker = new NumberChecker();

            Console.WriteLine($"8 is Even: {checker.IsEven(8)}");
            Console.WriteLine($"9 is Even: {checker.IsEven(9)}");

            Console.WriteLine();

            PerformanceTester performance = new PerformanceTester();

            Console.WriteLine(performance.LongRunningTask());

            Console.WriteLine();

            FileProcessor fileProcessor = new FileProcessor();

            string file = "sample.txt";

            fileProcessor.WriteToFile(file, "Welcome to NUnit Testing");

            Console.WriteLine(fileProcessor.ReadFromFile(file));

            Console.WriteLine();

            BankAccount account = new BankAccount();

            account.Deposit(5000);
            account.Withdraw(1500);

            Console.WriteLine($"Current Balance: {account.GetBalance()}");

            Console.WriteLine();

            PasswordValidator validator = new PasswordValidator();

            Console.WriteLine($"Password123 : {validator.IsValid("Password123")}");
            Console.WriteLine($"password : {validator.IsValid("password")}");

            Console.WriteLine();

            TemperatureConverter converter = new TemperatureConverter();

            Console.WriteLine($"0°C = {converter.CelsiusToFahrenheit(0)}°F");
            Console.WriteLine($"212°F = {converter.FahrenheitToCelsius(212)}°C");

            Console.WriteLine();

            DateFormatter formatter = new DateFormatter();

            Console.WriteLine(formatter.FormatDate("2026-08-07"));

            Console.WriteLine();

            UserRegistration registration = new UserRegistration();

            bool registered = registration.RegisterUser(
                "Saurav",
                "saurav@gmail.com",
                "Password123");

            Console.WriteLine($"Registration Successful: {registered}");

            Console.WriteLine();
            Console.WriteLine("Program Executed Successfully.");
        }
    }
}