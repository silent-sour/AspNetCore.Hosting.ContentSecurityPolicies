using AspNetCore.Hosting.ContentSecurityPolicies.Models;
using AspNetCore.Hosting.ContentSecurityPolicies.Resources;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Builders
{
    internal static class ContentSecurityHeaderBuilder
    {
        public static string Build([NotNull] ContentSecurityPolicy policy)
        {
            var stringBuilder = new StringBuilder();
            TryAddPolicySource(stringBuilder, policy.DefaultSrc, CspDirectiveResources.DefaultSrc);
            TryAddPolicySource(stringBuilder, policy.ScriptSrc, CspDirectiveResources.ScriptSrc);
            TryAddPolicySource(stringBuilder, policy.ScriptSrcAttr, CspDirectiveResources.ScriptSrcAttr);
            TryAddPolicySource(stringBuilder, policy.ScriptSrcElem, CspDirectiveResources.ScriptSrcElem);
            TryAddPolicySource(stringBuilder, policy.StyleSrc, CspDirectiveResources.StyleSrc);
            TryAddPolicySource(stringBuilder, policy.StyleSrcAttr, CspDirectiveResources.StyleSrcAttr);
            TryAddPolicySource(stringBuilder, policy.StyleSrcElem, CspDirectiveResources.StyleSrcElem);
            TryAddPolicySource(stringBuilder, policy.ImgSrc, CspDirectiveResources.ImgSrc);
            TryAddPolicySource(stringBuilder, policy.ConnectSrc, CspDirectiveResources.ConnectSrc);
            TryAddPolicySource(stringBuilder, policy.FontSrc, CspDirectiveResources.FontSrc);
            TryAddPolicySource(stringBuilder, policy.ObjectSrc, CspDirectiveResources.ObjectSrc);
            TryAddPolicySource(stringBuilder, policy.MediaSrc, CspDirectiveResources.MediaSrc);
            TryAddPolicySource(stringBuilder, policy.ChildSrc, CspDirectiveResources.ChildSrc);
            TryAddPolicySource(stringBuilder, policy.FormAction, CspDirectiveResources.FormAction);
            TryAddPolicySource(stringBuilder, policy.FrameAncestors, CspDirectiveResources.FrameAncestors);
            TryAddPolicySource(stringBuilder, policy.FrameSrc, CspDirectiveResources.FrameSrc);
            TryAddPolicySource(stringBuilder, policy.ManifestSrc, CspDirectiveResources.ManifestSource);
            TryAddPolicySource(stringBuilder, policy.WorkerSrc, CspDirectiveResources.WorkerSource);
            TryAddSandbox(stringBuilder, policy);
            TryUpgradeInsecureRequests(stringBuilder, policy);
            return stringBuilder.ToString().TrimEnd();
        }

        private static void TryUpgradeInsecureRequests([NotNull] StringBuilder stringBuilder, [NotNull] ContentSecurityPolicy policy)
        {
            if (policy.UpgradeInsecureRequests)
            {
                stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0}; ", CspDirectiveResources.UpgradeInsecureRequests);
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
                stringBuilder.AppendFormat(CultureInfo.InvariantCulture, " {0} {1}; ", CspDirectiveResources.Sandbox, policy.Sandbox.Value);
            }
        }
    }
}