using InsuranceClaimAdjudication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InsuranceClaimAdjudication.Resources
{
    internal class ClaimProcessingSession : IDisposable
    {
    private DocumentVerifier verifier;
    private bool disposed;

    public DocumentVerifier Verifier => verifier;
    public bool WasDisposed => disposed;

    public ClaimProcessingSession(string reportPath)
    {
        verifier = new DocumentVerifier();
    }

    public void Dispose()
    {
        if (disposed) return;

        try
        {
            try
            {
                verifier?.Dispose();
            }
            finally
            {
                
            }
        }
        finally
        {
            disposed = true;
            GC.SuppressFinalize(this);
        }
    }

    ~ClaimProcessingSession()
    {
        Dispose();
    }
}
}
