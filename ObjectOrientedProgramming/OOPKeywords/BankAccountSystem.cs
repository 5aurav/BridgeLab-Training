using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPKeywords
{
    internal class BankAccountSystem
    {
        public string AccountHolderName;
        public readonly int AccountNumber;
        public double Balance;

        static string BankName = "State Bank of India";
        static int TotalAccounts = 0;

        public BankAccountSystem(string AccountHolderName, int AccountNumber, double Balance)
        {
            this.AccountHolderName = AccountHolderName;
            this.AccountNumber = AccountNumber;
            this.Balance = Balance;

            TotalAccounts++;
        }

        public void DisplayDetails()
        {
            Console.WriteLine("Bank Name      : " + BankName);
            Console.WriteLine("Account Holder : " + AccountHolderName);
            Console.WriteLine("Account Number : " + AccountNumber);
            Console.WriteLine("Balance        : " + Balance);
        }

        public static void GetTotalAccounts()
        {
            Console.WriteLine("Total Accounts : " + TotalAccounts);
        }

        public static void display()
        {
            BankAccountSystem account1 = new BankAccountSystem("Saurav", 1001, 25000);
            BankAccountSystem account2 = new BankAccountSystem("Rahul", 1002, 18000);

            if (account1 is BankAccountSystem)
            {
                Console.WriteLine("Account 1 Details");
                account1.DisplayDetails();
            }

            Console.WriteLine();

            if (account2 is BankAccountSystem)
            {
                Console.WriteLine("Account 2 Details");
                account2.DisplayDetails();
            }

            Console.WriteLine();

            GetTotalAccounts();
        }
    }
}
