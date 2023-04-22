using AspNetCore.Hosting.ContentSecurityPolicies.Resources;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Builders
{
    public static class PolicyConstantBuilder
    {
        /// <summary>
        /// A whitelist for specific inline scripts using a cryptographic nonce (number used once). The server must generate a unique nonce value each time it transmits a policy. It is critical to provide an unguessable nonce, as bypassing a resource’s policy is otherwise trivial. See unsafe inline script for an example.
        /// </summary>
        /// <param name="base64Value"></param>
        /// <returns></returns>
        public static string Nonce(string base64Value)
        {
            return ContentSecurityPolicyResources.NonceHyphen + base64Value;
        }

        /// <summary>
        /// A sha256, of inline scripts or styles. When generating the hash, don't include the <script> or <style> tags and note that capitalization and whitespace matter, including leading or trailing whitespace.
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static string Sha256(string hash)
        {
            return ContentSecurityPolicyResources.Sha256 + hash;
        }

        /// <summary>
        /// A sha384 of inline scripts or styles. When generating the hash, don't include the <script> or <style> tags and note that capitalization and whitespace matter, including leading or trailing whitespace.
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static string Sha384(string hash)
        {
            return ContentSecurityPolicyResources.Sha384 + hash;
        }

        /// <summary>
        /// A sha512 of inline scripts or styles. When generating the hash, don't include the <script> or <style> tags and note that capitalization and whitespace matter, including leading or trailing whitespace.
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static string Sha512(string hash)
        {
            return ContentSecurityPolicyResources.Sha512 + hash;
        }
    }
}
