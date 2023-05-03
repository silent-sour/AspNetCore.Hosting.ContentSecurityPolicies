using AspNetCore.Hosting.ContentSecurityPolicies.Resources;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Builders
{
    /// <summary>
    /// Class for building hash-concatenated strings
    /// </summary>
    public static class PolicyConstantBuilder
    {
        /// <summary>
        /// A whitelist for specific inline scripts using a cryptographic nonce (number used once). The server must generate a unique nonce value each time it transmits a policy. It is critical to provide an unguessable nonce, as bypassing a resource’s policy is otherwise trivial. See unsafe inline script for an example.
        /// </summary>
        /// <param name="base64Value"></param>
        /// <returns></returns>
        public static string Nonce([NotNull] ReadOnlySpan<char> base64Value)
        {
            return JoinSpans(ContentSecurityPolicyResources.NonceHyphen, base64Value);
        }

        /// <summary>
        /// A sha256, of inline scripts or styles. When generating the hash, don't include the <script> or <style> tags and note that capitalization and whitespace matter, including leading or trailing whitespace.
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static string Sha256([NotNull] ReadOnlySpan<char> hash)
        {
            return JoinSpans(ContentSecurityPolicyResources.Sha256, hash);
        }

        /// <summary>
        /// A sha384 of inline scripts or styles. When generating the hash, don't include the <script> or <style> tags and note that capitalization and whitespace matter, including leading or trailing whitespace.
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static string Sha384([NotNull] ReadOnlySpan<char> hash)
        {
            return JoinSpans(ContentSecurityPolicyResources.Sha384, hash);
        }

        /// <summary>
        /// A sha512 of inline scripts or styles. When generating the hash, don't include the <script> or <style> tags and note that capitalization and whitespace matter, including leading or trailing whitespace.
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static string Sha512([NotNull] ReadOnlySpan<char> hash)
        {
            return JoinSpans(ContentSecurityPolicyResources.Sha512, hash);
        }

        private static string JoinSpans([NotNull] ReadOnlySpan<char> encodingSpan, [NotNull] ReadOnlySpan<char> valueSpan)
        {
            return new StringBuilder(encodingSpan.Length + valueSpan.Length)
                .Append(encodingSpan)
                .Append(valueSpan)
                .ToString();
        }
    }
}
