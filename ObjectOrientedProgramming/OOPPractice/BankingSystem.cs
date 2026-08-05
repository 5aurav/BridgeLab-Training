using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPractice
{
    interface ILoanable
    {
        void ApplyForLoan(double loanAmount);
        bool CalculateLoanEligibility();
    }

    abstract class BankAccount
    {
        private int accountNumber;
        private string holderName;
        private double balance;

        public int AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        public string HolderName
        {
            get { return holderName; }
            set { holderName = value; }
        }

        public double Balance
        {
            get { return balance; }
            protected set { balance = value; }
        }

        public BankAccount(int accountNumber, string holderName, double balance)
        {
            AccountNumber = accountNumber;
            HolderName = holderName;
            Balance = balance;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposited Amount : {amount}");
        }

        public void Withdraw(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrawn Amount : {amount}");
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }

        public abstract double CalculateInterest();

        public void DisplayDetails()
        { 
            Console.WriteLine($"Account Number : {AccountNumber}");
            Console.WriteLine($"Holder Name    : {HolderName}");
            Console.WriteLine($"Balance        : {Balance}");
        }
    }

    class SavingsAccount : BankAccount, ILoanable
    {
        public SavingsAccount(int accountNumber, string holderName, double balance)
            : base(accountNumber, holderName, balance)
        {
        }

        public override double CalculateInterest()
        {
            return Balance * 0.05;
        }

        public void ApplyForLoan(double loanAmount)
        {
            Console.WriteLine($"Loan Applied : {loanAmount}");
        }

        public bool CalculateLoanEligibility()
        {
            return Balance >= 50000;
        }
    }

    class CurrentAccount : BankAccount, ILoanable
    {
        public CurrentAccount(int accountNumber, string holderName, double balance)
            : base(accountNumber, holderName, balance)
        {
        }

        public override double CalculateInterest()
        {
            return Balance * 0.02;
        }

        public void ApplyForLoan(double loanAmount)
        {
            Console.WriteLine($"Loan Applied : {loanAmount}");
        }

        public bool CalculateLoanEligibility()
        {
            return Balance >= 100000;
        }
    }

    class BankingSystem
    {
        public static void Run()
        {
            List<BankAccount> accounts = new List<BankAccount>();

            SavingsAccount account1 = new SavingsAccount(1001, "Rahul", 80000);
            CurrentAccount account2 = new CurrentAccount(1002, "Priya", 150000);

            accounts.Add(account1);
            accounts.Add(account2);

            foreach (BankAccount account in accounts)
            {
                account.DisplayDetails();

                account.Deposit(5000);
                account.Withdraw(3000);

                Console.WriteLine($"Interest : {account.CalculateInterest()}");

                if (account is ILoanable loan)
                {
                    loan.ApplyForLoan(200000);

                    if (loan.CalculateLoanEligibility())
                    {
                        Console.WriteLine("Loan Status : Eligible");
                    }
                    else
                    {
                        Console.WriteLine("Loan Status : Not Eligible");
                    }
                }

                Console.WriteLine($"Updated Balance : {account.Balance}");
                Console.WriteLine();
            }
        }
    }
}
