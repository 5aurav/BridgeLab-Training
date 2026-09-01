using InsuranceClaimAdjudication.Attributes;
using InsuranceClaimAdjudication.Closures;
using InsuranceClaimAdjudication.Exceptions;
using InsuranceClaimAdjudication.InsuranceClaimAdjudication.Adjudication;
using InsuranceClaimAdjudication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimAdjudication
{
    internal class Program
    {

    [HighRiskCategory]
    public class HighRiskPolicyType { }

    [RequiredDocumentation("MedicalReport")]
    public class MedicalPolicyType { }

    public static void Main(string[] args)
        {
            var policies = new Dictionary<string, Policy>
        {
            { "P-HIGH", new Policy { PolicyId = "P-HIGH", CoverageLimit = 100000m, PolicyType = nameof(HighRiskPolicyType) } },
            { "P-MED", new Policy { PolicyId = "P-MED", CoverageLimit = 50000m, PolicyType = nameof(MedicalPolicyType) } },
            { "P-STD", new Policy { PolicyId = "P-STD", CoverageLimit = 75000m, PolicyType = "StandardPolicyType" } }
        };

            Func<string, Policy> lookupPolicy = id => policies.ContainsKey(id) ? policies[id] : null;

            Func<Claim, bool> coverageRule = claim =>
            {
                var policy = lookupPolicy(claim.PolicyId) ?? throw new InvalidOperationException("Policy not found");
                if (claim.ClaimedAmount > policy.CoverageLimit)
                    throw new ClaimExceedsCoverageException(claim.ClaimId, claim.ClaimedAmount, policy.CoverageLimit);
                return true;
            };

            Func<Claim, bool> exclusionRule = claim =>
            {
                var excluded = new[] { "Cosmetic", "Luxury" };
                foreach (var ex in excluded)
                    if (string.Equals(ex, claim.Category, StringComparison.OrdinalIgnoreCase))
                        throw new ExcludedCategoryException(claim.ClaimId, claim.Category);
                return true;
            };

            var fraudRiskFunc = Rules.CreateFraudRiskRule(0.8m);
            Predicate<Claim> docCheck = c => c.HasSupportingDocs;
            Action<Claim> logger = c => Console.WriteLine($"LOG: Processed {c.ClaimId}");

            var adjudicator = new ClaimAdjudicator(
                new[] { coverageRule, exclusionRule },
                fraudRiskFunc,
                docCheck,
                logger);

            adjudicator.ClaimAutoApproved += c =>
            {
                Console.WriteLine($"Auto-approved {c.ClaimId}: Approved {c.ClaimedAmount:C}");
            };
            adjudicator.ClaimEscalatedForReview += c =>
            {
                Console.WriteLine($"Escalated {c.ClaimId} for manual review (Category={c.Category})");
            };

            var claims = new List<Claim>
        {
            new Claim { ClaimId = "CLM-1001", PolicyId = "P-STD", ClaimedAmount = 45000m, Category = "Dental", HasSupportingDocs = true },
            new Claim { ClaimId = "CLM-1002", PolicyId = "P-MED", ClaimedAmount = 60000m, Category = "Medical", HasSupportingDocs = false },
            new Claim { ClaimId = "CLM-1003", PolicyId = "P-HIGH", ClaimedAmount = 30000m, Category = "Surgery", HasSupportingDocs = false },
            new Claim { ClaimId = "CLM-1004", PolicyId = "P-STD", ClaimedAmount = 10000m, Category = "Cosmetic", HasSupportingDocs = true }
        };

            var reportPath = Path.Combine(Path.GetTempPath(), "claims_report.txt");

            try
            {
                adjudicator.ProcessBatch(claims, lookupPolicy, reportPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Batch processing stopped with exception: {ex.Message}");
            }

            Console.WriteLine("Processing complete. Report: " + reportPath);
        }
    }
}
