using AspNetCore.Hosting.ContentSecurityPolicies.Builders;
using AspNetCore.Hosting.ContentSecurityPolicies.Resources;

using System.Diagnostics.CodeAnalysis;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Test.UnitTests
{
    [ExcludeFromCodeCoverage]
    public class PolicyConstantBuilderTests
    {
        [Fact]
        public void Test()
        {
            const string value = "test";
            var nonce = PolicyConstantBuilder.Nonce(value);
            Assert.Equal($"{ContentSecurityPolicyResources.NonceHyphen}{value}", nonce);

            var sha256 = PolicyConstantBuilder.Sha256("test");
            Assert.Equal($"{ContentSecurityPolicyResources.Sha256}{value}", sha256);

            var sha384 = PolicyConstantBuilder.Sha384("test");
            Assert.Equal($"{ContentSecurityPolicyResources.Sha384}{value}", sha384);

            var sha512 = PolicyConstantBuilder.Sha512("test");
            Assert.Equal($"{ContentSecurityPolicyResources.Sha512}{value}", sha512);
        }
    }
}
