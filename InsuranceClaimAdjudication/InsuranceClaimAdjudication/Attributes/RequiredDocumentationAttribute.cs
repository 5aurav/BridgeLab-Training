using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimAdjudication.Attributes
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method)]
    public class RequiredDocumentationAttribute:Attribute
    {
        public string DocumentName { get; }
        public RequiredDocumentationAttribute(string DocName)
        {
            DocumentName = DocName;
        }
    }
}
