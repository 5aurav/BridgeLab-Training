using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimAdjudication.Exceptions
{
    internal class ExcludedCategoryException:Exception
    {
        public string ClaimId { get; }
        public string Category { get;  }
        public ExcludedCategoryException(string claimId,string category):base($"Claim {claimId} is in excluded category '{category}'.")
        {
            ClaimId = claimId;
            Category = category;
        }
    }
}
