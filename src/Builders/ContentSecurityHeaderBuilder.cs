using AspNetCore.Hosting.ContentSecurityPolicies.Models;
using AspNetCore.Hosting.ContentSecurityPolicies.Resources;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Builders
{
    /// <summary>
    /// Class for building the Content Security Policy Header string from a policy object
    /// </summary>
    internal static class ContentSecurityHeaderBuilder
    {
        /// <summary>
        /// Builds a building the Content Security Policy Header string from a policy object
        /// </summary>
        /// <param name="policy">The policy</param>
        /// <returns>The header string</returns>
        public static string Build([NotNull] ContentSecurityPolicy policy)
        {
            var stringBuilder = new StringBuilder();
            TryAddPolicySource(stringBuilder, policy.DefaultSrc, ContentSecurityDirectiveResources.DefaultSrc);
            TryAddPolicySource(stringBuilder, policy.ScriptSrc, ContentSecurityDirectiveResources.ScriptSrc);
            TryAddPolicySource(stringBuilder, policy.ScriptSrcAttr, ContentSecurityDirectiveResources.ScriptSrcAttr);
            TryAddPolicySource(stringBuilder, policy.ScriptSrcElem, ContentSecurityDirectiveResources.ScriptSrcElem);
            TryAddPolicySource(stringBuilder, policy.StyleSrc, ContentSecurityDirectiveResources.StyleSrc);
            TryAddPolicySource(stringBuilder, policy.StyleSrcAttr, ContentSecurityDirectiveResources.StyleSrcAttr);
            TryAddPolicySource(stringBuilder, policy.StyleSrcElem, ContentSecurityDirectiveResources.StyleSrcElem);
            TryAddPolicySource(stringBuilder, policy.ImgSrc, ContentSecurityDirectiveResources.ImgSrc);
            TryAddPolicySource(stringBuilder, policy.ConnectSrc, ContentSecurityDirectiveResources.ConnectSrc);
            TryAddPolicySource(stringBuilder, policy.FontSrc, ContentSecurityDirectiveResources.FontSrc);
            TryAddPolicySource(stringBuilder, policy.ObjectSrc, ContentSecurityDirectiveResources.ObjectSrc);
            TryAddPolicySource(stringBuilder, policy.MediaSrc, ContentSecurityDirectiveResources.MediaSrc);
            TryAddPolicySource(stringBuilder, policy.ChildSrc, ContentSecurityDirectiveResources.ChildSrc);
            TryAddPolicySource(stringBuilder, policy.FormAction, ContentSecurityDirectiveResources.FormAction);
            TryAddPolicySource(stringBuilder, policy.FrameAncestors, ContentSecurityDirectiveResources.FrameAncestors);
            TryAddPolicySource(stringBuilder, policy.FrameSrc, ContentSecurityDirectiveResources.FrameSrc);
            TryAddPolicySource(stringBuilder, policy.ManifestSrc, ContentSecurityDirectiveResources.ManifestSource);
            TryAddPolicySource(stringBuilder, policy.WorkerSrc, ContentSecurityDirectiveResources.WorkerSource);
            TryAddSandbox(stringBuilder, policy);
            TryUpgradeInsecureRequests(stringBuilder, policy);
            return stringBuilder.ToString().TrimEnd();
        }

        private static void TryUpgradeInsecureRequests([NotNull] StringBuilder stringBuilder, [NotNull] ContentSecurityPolicy policy)
        {
            if (policy.UpgradeInsecureRequests)
            {
                stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0}; ", ContentSecurityDirectiveResources.UpgradeInsecureRequests);
            }
        }

        private static void TryAddPolicySource([NotNull] StringBuilder stringBuilder, [NotNull] HashSet<string> policySource, [NotNull] string cspHeaderValue)
        {
            if (policySource.Count > 0)
            {
                stringBuilder.AppendFormat(CultureInfo.InvariantCulture, " {0} {1}; ", cspHeaderValue, string.Join(' ', policySource));
            }
        }

        private static void TryAddSandbox([NotNull] StringBuilder stringBuilder, [NotNull] ContentSecurityPolicy policy)
        {
            if (policy.Sandbox != null)
            {
                stringBuilder.AppendFormat(CultureInfo.InvariantCulture, " {0} {1}; ", ContentSecurityDirectiveResources.Sandbox, policy.Sandbox.Value);
            }
        }
    }
}