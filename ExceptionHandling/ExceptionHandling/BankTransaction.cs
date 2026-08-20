using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class BankTransaction
    {
        public static void Run()
        {
            BankAccount account = new BankAccount(10000);

            try
            {
                Console.Write("Enter withdrawal amount: ");
                double amount = double.Parse(Console.ReadLine());

                account.Withdraw(amount);

                Console.WriteLine(
                    $"Withdrawal successful, new balance: {account.Balance}"
                );
            }
            catch (InsufficientFundsException)
            {
                Console.WriteLine("Insufficient balance!");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid amount!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format!");
            }
        }
    }
}
