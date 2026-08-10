using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.SystemDesignProblems
{
    public class BankingSystem
    {
        public static void Run()
        {
            Dictionary<int, double> accounts = new Dictionary<int, double>()
        {
            { 101, 50000 },
            { 102, 25000 },
            { 103, 75000 },
            { 104, 15000 }
        };

            SortedDictionary<double, int> sortedAccounts = new SortedDictionary<double, int>();

            foreach (var account in accounts)
                sortedAccounts[account.Value] = account.Key;

            Console.WriteLine("Customers Sorted by Balance:");

            foreach (var account in sortedAccounts)
                Console.WriteLine(
                    $"Account: {account.Value}, Balance: {account.Key}");

            Queue<(int Account, double Amount)> withdrawals = new Queue<(int Account, double Amount)>();

            withdrawals.Enqueue((101, 5000));
            withdrawals.Enqueue((103, 10000));
            withdrawals.Enqueue((102, 3000));

            Console.WriteLine("\nProcessing Withdrawals:");

            while (withdrawals.Count > 0)
            {
                var request = withdrawals.Dequeue();

                if (accounts[request.Account] >= request.Amount)
                {
                    accounts[request.Account] -= request.Amount;

                    Console.WriteLine(
                        $"Account {request.Account}: Withdrawn {request.Amount}");
                }
                else
                {
                    Console.WriteLine(
                        $"Account {request.Account}: Insufficient Balance");
                }
            }

            Console.WriteLine("\nUpdated Balances:");

            foreach (var account in accounts)
                Console.WriteLine(
                    $"Account {account.Key}: {account.Value}");
        }
    }
}
