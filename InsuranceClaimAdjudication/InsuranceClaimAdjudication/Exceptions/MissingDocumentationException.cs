using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimAdjudication.Exceptions
{
    internal class MissingDocumentationException : Exception
    {
        public MissingDocumentationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
