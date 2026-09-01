using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimAdjudication.Attributes
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method)]
    internal class HighRiskCategoryAttribute:Attribute
    {

    }
}
