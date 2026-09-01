using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimAdjudication.Exceptions
{
    internal class ClaimExceedsCoverageException:Exception
    {
        public string ClaimId { get;}
        public decimal ClaimAmount { get; }
        public decimal CoverageLimit { get; }

        public ClaimExceedsCoverageException(string claimId,decimal amount,decimal limit) : base($"Claim {claimId} for {amount:C} exceeds coverage {limit:C}.")
        {
            ClaimId = claimId;
            ClaimAmount = amount;
            CoverageLimit = limit;
        }
    }
}
