using InsuranceClaimAdjudication;
using InsuranceClaimAdjudication.Closures;
using InsuranceClaimAdjudication ;
using InsuranceClaimAdjudication.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security.Claims;
using Claim = InsuranceClaimAdjudication.Models.Claim;

namespace InsuranceClaimTesting
{
    public class Tests
    {
        private Func<string, Policy> BuildPolicyLookup()
        {
            var policies = new Dictionary<string, Policy>
            {
                { "P1", new Policy { PolicyId = "P1", CoverageLimit = 50000m, PolicyType = "StandardPolicyType" } },
                { "P2", new Policy { PolicyId = "P2", CoverageLimit = 100000m, PolicyType = "HighRiskPolicyType" } }
            };
            return id => policies.ContainsKey(id) ? policies[id] : null;
        }

        private InsuranceClaimAdjudication.InsuranceClaimAdjudication.Adjudication.ClaimAdjudicator BuildAdjudicator(Func<Claim, Policy, decimal> fraudFunc = null, Predicate<Claim> docCheck = null, Action<Claim> logger = null)
        {
            var coverageRule = Rules.CreateCoverageLimitRule(50000m);
            var exclusionRule = Rules.CreateExclusionRule(new[] { "ExcludedCat" });
            var fraud = fraudFunc;
            var doc = docCheck;
            var log = logger;
            return new InsuranceClaimAdjudication.InsuranceClaimAdjudication.Adjudication.ClaimAdjudicator(new[] { coverageRule, exclusionRule }, fraud, doc, log);
        }
        [Test]
        public void ClaimWithinLimits_AutoApproves()
        {
            var lookup = BuildPolicyLookup();
            var adjudicator = BuildAdjudicator();
            var approved = false;
            var escalated = false;
            adjudicator.ClaimAutoApproved += c => approved = true;
            adjudicator.ClaimEscalatedForReview += c => escalated = true;
            var claim = new Claim { ClaimId = "T1", PolicyId = "P1", ClaimedAmount = 1000m, Category = "Routine", HasSupportingDocs = true };
            adjudicator.ProcessClaim(claim, lookup, Path.GetTempFileName());
            Assert.IsTrue(approved);
            Assert.IsFalse(escalated);
        }

        [Test]
        public void ClaimExceedingLimit_ThrowsCoverageExceptionEquivalent()
        {
            var lookup = BuildPolicyLookup();
            var adjudicator = BuildAdjudicator();
            var claim = new InsuranceClaimAdjudication.Models.Claim { ClaimId = "T2", PolicyId = "P1", ClaimedAmount = 60000m, Category = "Routine", HasSupportingDocs = true };
            var ex = Assert.Throws<Exception>(() => adjudicator.ProcessClaim(claim, lookup, Path.GetTempFileName()));
            Assert.That(ex.Message, Does.Contain("exceeds coverage").IgnoreCase);
        }

        [Test]
        public void ExcludedCategory_ThrowsExcludedExceptionEquivalent()
        {
            var lookup = BuildPolicyLookup();
            var adjudicator = BuildAdjudicator();
            var claim = new Claim { ClaimId = "T3", PolicyId = "P1", ClaimedAmount = 100m, Category = "ExcludedCat", HasSupportingDocs = true };
            var ex = Assert.Throws<Exception>(() => adjudicator.ProcessClaim(claim, lookup, Path.GetTempFileName()));
            Assert.That(ex.Message, Does.Contain("excluded category").IgnoreCase);
        }

        [Test]
        public void MissingDocumentation_WrappedFileNotFound_RethrownWithInner()
        {
            var lookup = BuildPolicyLookup();
            var adjudicator = BuildAdjudicator(null, c => false, null);
            var claim = new InsuranceClaimAdjudication.Models.Claim { ClaimId = "T4", PolicyId = "P1", ClaimedAmount = 100m, Category = "Routine", HasSupportingDocs = false };
            var ex = Assert.Throws<Exception>(() => adjudicator.ProcessClaim(claim, lookup, Path.GetTempFileName()));
            Assert.IsNotNull(ex.InnerException);
            Assert.IsInstanceOf<FileNotFoundException>(ex.InnerException);
        }
    }
}