using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.SystemDesignProblems
{
    public class Policy
    {
        public string PolicyNumber { get; set; }
        public string CoverageType { get; set; }
        public DateTime ExpiryDate { get; set; }

        public Policy(string policyNumber, string coverageType, DateTime expiryDate)
        {
            PolicyNumber = policyNumber;
            CoverageType = coverageType;
            ExpiryDate = expiryDate;
        }

        public override bool Equals(object obj)
        {
            return obj is Policy policy &&
                   PolicyNumber == policy.PolicyNumber;
        }

        public override int GetHashCode()
        {
            return PolicyNumber.GetHashCode();
        }
    }

    public class InsurancePolicySystem
    {
        public static void Run()
        {
            HashSet<Policy> policies = new HashSet<Policy>();

            policies.Add(new Policy(
                "P101", "Health", DateTime.Today.AddDays(10)));

            policies.Add(new Policy(
                "P102", "Life", DateTime.Today.AddDays(20)));

            policies.Add(new Policy(
                "P103", "Health", DateTime.Today.AddDays(60)));

            policies.Add(new Policy(
                "P101", "Health", DateTime.Today.AddDays(10)));

            Console.WriteLine("Unique Policies:");

            foreach (Policy policy in policies)
                Console.WriteLine(policy.PolicyNumber);

            Console.WriteLine("\nExpiring within 30 days:");

            foreach (Policy policy in policies)
            {
                if (policy.ExpiryDate <= DateTime.Today.AddDays(30))
                    Console.WriteLine(policy.PolicyNumber);
            }

            Console.WriteLine("\nHealth Policies:");

            foreach (Policy policy in policies)
            {
                if (policy.CoverageType == "Health")
                    Console.WriteLine(policy.PolicyNumber);
            }

            Console.WriteLine("\nSorted by Expiry Date:");

            SortedSet<Policy> sortedPolicies =
                new SortedSet<Policy>(
                    Comparer<Policy>.Create(
                        (a, b) => a.ExpiryDate.CompareTo(b.ExpiryDate)));

            foreach (Policy policy in policies)
                sortedPolicies.Add(policy);

            foreach (Policy policy in sortedPolicies)
                Console.WriteLine(
                    $"{policy.PolicyNumber} - {policy.ExpiryDate:dd-MM-yyyy}");
        }
    }
}
