using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimAdjudication.Models
{
    public class Claim
    {
        public string ClaimId { get; set; }
        public string PolicyId { get; set; }
        public decimal ClaimedAmount { get; set; }
        public string Category { get; set; }
        public bool HasSupportingDocs { get; set; }
    }
}
