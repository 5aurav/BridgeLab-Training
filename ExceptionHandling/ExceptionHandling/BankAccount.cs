using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class BankAccount
    {
        public double Balance { get; private set; }

        public BankAccount(double balance)
        {
            Balance = balance;
        }

        public void Withdraw(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Invalid amount!");
            }

            if (amount > Balance)
            {
                throw new InsufficientFundsException(
                    "Insufficient balance!"
                );
            }

            Balance -= amount;
        }
    }
}
