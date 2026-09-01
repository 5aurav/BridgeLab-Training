using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceClaimAdjudication.Models;

namespace InsuranceClaimAdjudication.Resources
{
    internal class DocumentVerifier:IDisposable
    {
        private bool disposed;
        public bool wasDisposed => disposed;

        public void verify(Claim claim)
        {
            if (!claim.HasSupportingDocs)
            {
                throw new FileNotFoundException($"Supporting docs not found for {claim.ClaimId}.");
            }
        }
        public void Dispose()
        {
            disposed = true;
        }
    }
}
