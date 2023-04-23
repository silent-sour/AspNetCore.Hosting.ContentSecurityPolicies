using AspNetCore.Hosting.ContentSecurityPolicies.Builders;
using AspNetCore.Hosting.ContentSecurityPolicies.Models;
using AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox;
using AspNetCore.Hosting.ContentSecurityPolicies.Resources;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Test.UnitTests
{
    public class ContentSecurityHeaderBuilderTests
    {

        [Fact]
        public void TestBuildEmpty()
        {

            ContentSecurityPolicy policy = new();
            var header = BuildHeader(policy);
            Assert.NotEqual(string.Empty, header);
        }

        [Fact]
        public void TestBuildDefaultSrc()
        {

            ContentSecurityPolicy policy = new() { DefaultSrc = { ContentSecurityPolicyResources.Self } };
            Assert.NotEmpty(policy.DefaultSrc);

            var header = BuildHeader(policy);
            Assert.Contains($"{CspDirectiveResources.DefaultSrc} {ContentSecurityPolicyResources.Self};", header);
        }

        [Fact]
        public void TestBuildScriptSrc()
        {

            ContentSecurityPolicy policy = new() { ScriptSrc = { ContentSecurityPolicyResources.Self } };
            Assert.NotEmpty(policy.ScriptSrc);

            var header = BuildHeader(policy);
            Assert.Contains($"{CspDirectiveResources.ScriptSrc} {ContentSecurityPolicyResources.Self};", header);
        }

        [Fact]
        public void TestBuildStyleSrc()
        {

            ContentSecurityPolicy policy = new() { StyleSrc = { ContentSecurityPolicyResources.Self } };
            Assert.NotEmpty(policy.StyleSrc);

            var header = BuildHeader(policy);
            Assert.Contains($"{CspDirectiveResources.StyleSrc} {ContentSecurityPolicyResources.Self};", header);
        }



        [Fact]
        public void TestBuildStyleAttrSrc()
        {

            ContentSecurityPolicy policy = new() { StyleSrcAttr = { ContentSecurityPolicyResources.Self } };
            Assert.NotEmpty(policy.StyleSrcAttr);

            var header = BuildHeader(policy);
            Assert.Contains($"{CspDirectiveResources.StyleSrcAttr} {ContentSecurityPolicyResources.Self};", header);
        }



        [Fact]
        public void TestBuildStyleElemSrc()
        {

            ContentSecurityPolicy policy = new() { StyleSrcElem = { ContentSecurityPolicyResources.Self } };
            Assert.NotEmpty(policy.StyleSrcElem);

            var header = BuildHeader(policy);
            Assert.Contains($"{CspDirectiveResources.StyleSrcElem} {ContentSecurityPolicyResources.Self};", header);
        }

        [Fact]
        public void TestUpgradeInsecureRequests()
        {
            ContentSecurityPolicy policy = new() { UpgradeInsecureRequests = true };
            Assert.True(policy.UpgradeInsecureRequests);

            var header = BuildHeader(policy);
            Assert.Contains($"{CspDirectiveResources.UpgradeInsecureRequests};", header);
        }

        [Fact]
        public void TestSandbox()
        {
            ContentSecurityPolicy policy = new() { Sandbox = new AllowPopupsToEscapeSandbox() };
            Assert.NotNull(policy.Sandbox);
            var header = BuildHeader(policy);
            Assert.Contains($"{CspDirectiveResources.Sandbox} {policy.Sandbox.Value};", header);
        }

        public static string BuildHeader(ContentSecurityPolicy policy)
        {
            var header = ContentSecurityHeaderBuilder.Build(policy);
            Assert.NotNull(header);
            return header;
        }
    }
}