using System;

namespace NUnitPrograms
{
    public class BankAccount
    {
        private double balance;

        public void Deposit(double amount)
        {
            balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount > balance)
                throw new InvalidOperationException("Insufficient balance.");

            balance -= amount;
        }

        public double GetBalance()
        {
            return balance;
        }
    }
}