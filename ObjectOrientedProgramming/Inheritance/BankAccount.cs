using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class BankAccount
    {
        public int AccountNumber { get; set; }
        public double Balance { get; set; }

        public BankAccount(int accountNumber, double balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public virtual void DisplayAccountType()
        {
            Console.WriteLine($"Account Number : {AccountNumber}");
            Console.WriteLine($"Balance : {Balance}");
        }
    }

    class SavingsAccount : BankAccount
    {
        public double InterestRate { get; set; }

        public SavingsAccount(int accountNumber, double balance, double interestRate)
            : base(accountNumber, balance)
        {
            InterestRate = interestRate;
        }

        public override void DisplayAccountType()
        {
            Console.WriteLine("Savings Account");
            base.DisplayAccountType();
            Console.WriteLine($"Interest Rate : {InterestRate}%");
        }
    }

    class CheckingAccount : BankAccount
    {
        public double WithdrawalLimit { get; set; }

        public CheckingAccount(int accountNumber, double balance, double withdrawalLimit)
            : base(accountNumber, balance)
        {
            WithdrawalLimit = withdrawalLimit;
        }

        public override void DisplayAccountType()
        {
            Console.WriteLine("Checking Account");
            base.DisplayAccountType();
            Console.WriteLine($"Withdrawal Limit : {WithdrawalLimit}");
        }
    }

    class FixedDepositAccount : BankAccount
    {
        public int DepositPeriod { get; set; }

        public FixedDepositAccount(int accountNumber, double balance, int depositPeriod)
            : base(accountNumber, balance)
        {
            DepositPeriod = depositPeriod;
        }

        public override void DisplayAccountType()
        {
            Console.WriteLine("Fixed Deposit Account");
            base.DisplayAccountType();
            Console.WriteLine($"Deposit Period : {DepositPeriod} Years");
        }
    }

    internal class BankDisplay
    {
        public static void ShowAccounts()
        {
            BankAccount[] accounts =
            {
                new SavingsAccount(101,50000,5.5),
                new CheckingAccount(102,35000,10000),
                new FixedDepositAccount(103,100000,5)
            };

            foreach (BankAccount account in accounts)
            {
                account.DisplayAccountType();
                Console.WriteLine();
            }
        }
    }
}
