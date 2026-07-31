using System;

namespace AccessModifiers
{
    class BankAccount
    {
        public string accountNumber;
        protected string accountHolder;
        private double balance;

        public BankAccount(string accountNumber, string accountHolder, double balance)
        {
            this.accountNumber = accountNumber;
            this.accountHolder = accountHolder;
            this.balance = balance;
        }

        public void SetBalance(double balance)
        {
            this.balance = balance;
        }

        public double GetBalance()
        {
            return balance;
        }
    }

    class SavingsAccount : BankAccount
    {
        public SavingsAccount(string accountNumber, string accountHolder, double balance)
            : base(accountNumber, accountHolder, balance)
        {
        }

        public void Display()
        {
            Console.WriteLine("Account Number : " + accountNumber);
            Console.WriteLine("Account Holder : " + accountHolder);
            Console.WriteLine("Balance        : " + GetBalance());
        }
    }

    class BankAccountManagement
    {
        public static void display()
        {
            SavingsAccount account = new SavingsAccount("1234567890", "Saurav", 25000);

            Console.WriteLine("Account Details");
            account.Display();

            Console.WriteLine();

            account.SetBalance(30000);

            Console.WriteLine("After Updating Balance");
            Console.WriteLine("Balance : " + account.GetBalance());
        }
    }
}