using AspNetCore.Hosting.ContentSecurityPolicies.Models;
using AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox;
using AspNetCore.Hosting.ContentSecurityPolicies.Resources;

using System.Diagnostics.CodeAnalysis;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Test.UnitTests
{
    [ExcludeFromCodeCoverage]
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
            TestSandbox(SandboxOptions.AllowTopNavigation);
        }

        private static void TestSandbox(SandboxOption sandbox)
        {
            ContentSecurityPolicy policy = new() { Sandbox = sandbox };
            Assert.NotNull(policy.Sandbox);
            var header = ContentSecurityHeaderBuilderTests.BuildHeader(policy);
            Assert.Contains($"{ContentSecurityDirectiveResources.Sandbox} {policy.Sandbox.Value};", header);
        }
    }
}
