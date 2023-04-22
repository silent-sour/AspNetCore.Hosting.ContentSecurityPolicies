using System;
using System.Collections.Generic;
using System.Text;

using AspNetCore.Hosting.ContentSecurityPolicies.Models;
using AspNetCore.Hosting.ContentSecurityPolicies.Resources;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Builders
{
    internal static class ContentSecurityHeaderBuilder
    {
        public static string Build(ContentSecurityPolicy policy)
        {
            var stringBuilder = new StringBuilder();
            TryAddPolicySource(policy.DefaultSrc, CspDirectiveResources.DefaultSrc, stringBuilder);
            TryAddPolicySource(policy.ScriptSrc, CspDirectiveResources.ScriptSrc, stringBuilder);
            TryAddPolicySource(policy.StyleSrc, CspDirectiveResources.StyleSrc, stringBuilder);
            TryAddPolicySource(policy.StyleSrcAttr, CspDirectiveResources.StyleSrcAttr, stringBuilder);
            TryAddPolicySource(policy.StyleSrcElem, CspDirectiveResources.StyleSrcElem, stringBuilder);
            TryAddPolicySource(policy.ImgSrc, CspDirectiveResources.ImgSrc, stringBuilder);
            TryAddPolicySource(policy.ConnectSrc, CspDirectiveResources.ConnectSrc, stringBuilder);
            TryAddPolicySource(policy.FontSrc, CspDirectiveResources.FontSrc, stringBuilder);
            TryAddPolicySource(policy.ObjectSrc, CspDirectiveResources.ObjectSrc, stringBuilder);
            TryAddPolicySource(policy.MediaSrc, CspDirectiveResources.MediaSrc, stringBuilder);
            TryAddPolicySource(policy.ChildSrc, CspDirectiveResources.ChildSrc, stringBuilder);
            TryAddPolicySource(policy.FormAction, CspDirectiveResources.FormAction, stringBuilder);
            TryAddPolicySource(policy.FrameAncestors, CspDirectiveResources.FrameAncestors, stringBuilder);
            TryAddPolicySource(policy.FrameSrc, CspDirectiveResources.FrameSrc, stringBuilder);
            TryAddPolicySource(policy.ManifestSrc, CspDirectiveResources.ManifestSource, stringBuilder);
            TryAddPolicySource(policy.WorkerSrc, CspDirectiveResources.WorkerSource, stringBuilder);
            TryAddSandbox(policy, stringBuilder);
            if (policy.UpgradeInsecureRequests)
            {
                stringBuilder.Append($"{CspDirectiveResources.UpgradeInsecureRequests}; ");
            }

            return stringBuilder.ToString().TrimEnd();
        }

        private static void TryAddPolicySource(HashSet<string> policySource, string cspHeaderValue, StringBuilder builder)
        {
            if (policySource.Count > 0)
            {
                builder.Append(cspHeaderValue);
                builder.Append($" {string.Join(" ", policySource)}; ");
            }
        }

        private static void TryAddSandbox(ContentSecurityPolicy policy, StringBuilder stringBuilder)
        {
            if (policy.Sandbox != null)
            {
                stringBuilder.Append(CspDirectiveResources.Sandbox);
                stringBuilder.Append($" {policy.Sandbox.Value}; ");
            }
        }
    }
}