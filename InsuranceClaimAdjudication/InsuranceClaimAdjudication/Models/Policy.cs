using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimAdjudication.Models
{
    public class Policy
    {
        public string PolicyId { get; set; }
        public decimal CoverageLimit { get; set; }
        public string PolicyType { get; set; }
    }
}
