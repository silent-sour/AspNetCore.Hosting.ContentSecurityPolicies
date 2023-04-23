using AspNetCore.Hosting.ContentSecurityPolicies.Models;
using AspNetCore.Hosting.ContentSecurityPolicies.Resources;
using AspNetCore.Hosting.ContentSecurityPolicies.Test.UnitTests;

using BenchmarkDotNet.Attributes;

using System.Diagnostics.CodeAnalysis;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Test.Benchmarks
{
    public class CspBenchmark
    {
        [Benchmark]
        [ExcludeFromCodeCoverage]
        public string DefaultSelfPolicy()
        {
            ContentSecurityPolicy policy = new() { DefaultSrc = { ContentSecurityPolicyResources.Self } };
            var header = ContentSecurityHeaderBuilderTests.BuildHeader(policy);
            return header;
        }

        [Benchmark]
        [ExcludeFromCodeCoverage]
        public string ScriptSrcSelfPolicy()
        {
            ContentSecurityPolicy policy = new() { ScriptSrc = { ContentSecurityPolicyResources.Self } };
            var header = ContentSecurityHeaderBuilderTests.BuildHeader(policy);
            return header;
        }

        [Benchmark]
        [ExcludeFromCodeCoverage]
        public string DefaultAndScriptSelfPolicy()
        {
            ContentSecurityPolicy policy = new() { DefaultSrc = { ContentSecurityPolicyResources.Self }, ScriptSrc = { ContentSecurityPolicyResources.Self } };
            var header = ContentSecurityHeaderBuilderTests.BuildHeader(policy);
            return header;
        }
    }
}
