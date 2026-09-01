using InsuranceClaimAdjudication.Attributes;
using InsuranceClaimAdjudication.Exceptions;
using InsuranceClaimAdjudication.Models;
using InsuranceClaimAdjudication.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimAdjudication
{

    namespace InsuranceClaimAdjudication.Adjudication
    {
        public class ClaimAdjudicator
        {
            public event Action<Claim> ClaimEscalatedForReview;
            public event Action<Claim> ClaimAutoApproved;

            private readonly List<Func<Claim, bool>> _rules;
            private readonly Func<Claim, Policy, decimal> _fraudRiskFunc;
            private readonly Predicate<Claim> _documentationCheck;
            private readonly Action<Claim> _logger;

            public decimal EscalationThreshold { get; set; } = 0.70m;

            public ClaimAdjudicator(
                IEnumerable<Func<Claim, bool>> rules,
                Func<Claim, Policy, decimal> fraudRiskFunc,
                Predicate<Claim> documentationCheck,
                Action<Claim> logger)
            {
                _rules = (rules ?? Enumerable.Empty<Func<Claim, bool>>()).ToList();
                _fraudRiskFunc = fraudRiskFunc ?? ((c, p) => 0m);
                _documentationCheck = documentationCheck ?? (_ => true);
                _logger = logger ?? (_ => { });
            }

            public void ProcessClaim(Claim claim, Func<string, Policy> lookupPolicy, string reportPath)
            {
                if (claim == null) throw new ArgumentNullException(nameof(claim));
                if (lookupPolicy == null) throw new ArgumentNullException(nameof(lookupPolicy));

                using (var session = new ClaimProcessingSession(reportPath))
                {
                    if (!_documentationCheck(claim))
                    {
                        try
                        {
                            session.Verifier.verify(claim);
                        }
                        catch (System.IO.FileNotFoundException fnf)
                        {
                            throw new MissingDocumentationException($"Missing docs for {claim.ClaimId}", fnf);
                        }
                    }

                    var policy = lookupPolicy(claim.PolicyId) ?? throw new InvalidOperationException($"Policy not found: {claim.PolicyId}");

                    foreach (var rule in _rules) rule(claim);

                    var risk = ComputeRisk(claim, policy);

                    if (risk >= EscalationThreshold)
                        ClaimEscalatedForReview?.Invoke(claim);
                    else
                        ClaimAutoApproved?.Invoke(claim);

                    _logger?.Invoke(claim);
                }
            }

            public void ProcessBatch(IEnumerable<Claim> claims, Func<string, Policy> lookupPolicy, string reportPath)
            {
                if (claims == null) throw new ArgumentNullException(nameof(claims));
                if (lookupPolicy == null) throw new ArgumentNullException(nameof(lookupPolicy));

                var list = claims.ToList();
                var duplicate = list.GroupBy(c => c.ClaimId).FirstOrDefault(g => g.Count() > 1);
                if (duplicate != null) throw new InvalidOperationException($"Duplicate ClaimId: {duplicate.Key}");

                foreach (var claim in list)
                {
                    try
                    {
                        ProcessClaim(claim, lookupPolicy, reportPath);
                    }
                    catch (MissingDocumentationException)
                    {
                        _logger?.Invoke(claim);
                    }
                    catch (ClaimExceedsCoverageException)
                    {
                        _logger?.Invoke(claim);
                    }
                    catch (ExcludedCategoryException)
                    {
                        _logger?.Invoke(claim);
                    }
                    catch (Exception)
                    {
                        _logger?.Invoke(claim);
                    }
                }
            }

            private decimal ComputeRisk(Claim claim, Policy policy)
            {
                decimal risk = 0m;

                var fraudComponent = _fraudRiskFunc?.Invoke(claim, policy) ?? 0m;
                risk += fraudComponent * 0.6m;

                var asm = Assembly.GetExecutingAssembly();
                var targetType = asm.GetTypes().FirstOrDefault(t => string.Equals(t.Name, policy.PolicyType));
                if (targetType != null)
                {
                    var isHighRisk = targetType.GetCustomAttributes(typeof(HighRiskCategoryAttribute), inherit: true).Any();
                    if (isHighRisk) risk += 0.20m;

                    var reqDocs = targetType.GetCustomAttributes(typeof(RequiredDocumentationAttribute), inherit: true)
                                            .Cast<RequiredDocumentationAttribute>()
                                            .Select(a => a.DocumentName)
                                            .ToList();
                    if (reqDocs.Any() && !claim.HasSupportingDocs) risk += 0.20m;
                }

                if (policy.CoverageLimit > 0m)
                {
                    var sizeRatio = claim.ClaimedAmount / policy.CoverageLimit;
                    risk += Math.Min(0.10m, (decimal)sizeRatio * 0.05m);
                }

                if (risk < 0m) risk = 0m;
                if (risk > 1m) risk = 1m;
                return risk;
            }
        }
    }
}
