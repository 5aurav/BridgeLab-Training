using InsuranceClaimAdjudication.Exceptions;
using InsuranceClaimAdjudication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimAdjudication.Closures
{
    public class Rules
    {
        public static Func<Claim, bool> CreateCoverageLimitRule(decimal limit) =>
           (claim) =>
           {
               if (claim.ClaimedAmount > limit)
                   throw new ClaimExceedsCoverageException(claim.ClaimId, claim.ClaimedAmount, limit);
               return true;
           };

        public static Func<Claim, bool> CreateExclusionRule(string[] excludedCategories) =>
            (claim) =>
            {
                foreach (var c in excludedCategories)
                    if (string.Equals(c, claim.Category))
                        throw new ExcludedCategoryException(claim.ClaimId, claim.Category);
                return true;
            };

        public static Func<Claim, Policy, decimal> CreateFraudRiskRule(decimal claimToLimitRatioThreshold) =>
            (claim, policy) =>
            {
                if (policy.CoverageLimit <= 0m) return 0m;
                var ratio = claim.ClaimedAmount / policy.CoverageLimit;
                return ratio >= claimToLimitRatioThreshold ? Math.Min(1m, ratio) : ratio * 0.5m;
            };
    }
}
