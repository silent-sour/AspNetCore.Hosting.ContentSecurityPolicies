using AspNetCore.Hosting.ContentSecurityPolicies.Builders;
using AspNetCore.Hosting.ContentSecurityPolicies.Models;
using AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox;
using AspNetCore.Hosting.ContentSecurityPolicies.Resources;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Test.UnitTests
{
    public class SandboxTests
    {
        [Fact]
        public void Test()
        {

            TestSandbox(SandboxOptions.AllowPopups);
            TestSandbox(SandboxOptions.AllowModals);
            TestSandbox(SandboxOptions.AllowForms);
            TestSandbox(SandboxOptions.AllowModals);
            TestSandbox(SandboxOptions.AllowOrientationLock);
            TestSandbox(SandboxOptions.AllowPointerLock);
            TestSandbox(SandboxOptions.AllowPopups);
            TestSandbox(SandboxOptions.AllowPopupsToEscapeSandbox);
            TestSandbox(SandboxOptions.AllowPresentation);
            TestSandbox(SandboxOptions.AllowSameOrigin);
            TestSandbox(SandboxOptions.AllowScripts);
            TestSandbox(SandboxOptions.AllowTopNaviation);
            var unionSandboxType = SandboxOptions.AllowPopups;
            unionSandboxType.Merge(SandboxOptions.AllowModals);
            TestSandbox(unionSandboxType);
        }

        private static void TestSandbox(BaseSandboxOption sandbox)
        {
            ContentSecurityPolicy policy = new() { Sandbox = sandbox };
            Assert.NotNull(policy.Sandbox);
            var header = ContentSecurityHeaderBuilderTests.BuildHeader(policy);
            Assert.Equal($"{CspDirectiveResources.Sandbox} {policy.Sandbox.Value};", header);
        }
    }
}
