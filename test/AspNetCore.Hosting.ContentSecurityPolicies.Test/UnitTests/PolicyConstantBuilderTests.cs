using AspNetCore.Hosting.ContentSecurityPolicies.Builders;
using AspNetCore.Hosting.ContentSecurityPolicies.Resources;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Test.UnitTests
{
    public class PolicyConstantBuilderTests
    {
        [Fact]
        public void Test()
        {
            var nonce = PolicyConstantBuilder.Nonce("test");
            Assert.Equal($"{ContentSecurityPolicyResources.NonceHyphen}test", nonce);

            var sha256 = PolicyConstantBuilder.Sha256("test");
            Assert.Equal($"{ContentSecurityPolicyResources.Sha256}test", sha256);

            var sha384 = PolicyConstantBuilder.Sha384("test");
            Assert.Equal($"{ContentSecurityPolicyResources.Sha384}test", sha384);

            var sha512 = PolicyConstantBuilder.Sha512("test");
            Assert.Equal($"{ContentSecurityPolicyResources.Sha512}test", sha512);
        }
    }
}
