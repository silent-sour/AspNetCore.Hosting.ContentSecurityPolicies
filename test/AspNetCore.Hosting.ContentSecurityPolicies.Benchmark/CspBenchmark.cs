using AspNetCore.Hosting.ContentSecurityPolicies.Models;
using AspNetCore.Hosting.ContentSecurityPolicies.Resources;
using AspNetCore.Hosting.ContentSecurityPolicies.Test.UnitTests;

using BenchmarkDotNet.Attributes;

using System.Diagnostics.CodeAnalysis;

#pragma warning disable CA1822 // Mark members as static
namespace AspNetCore.Hosting.ContentSecurityPolicies.Test.Benchmarks
{
    public class CspBenchmark
    {
        protected CspBenchmark()
        {

        }

        [Benchmark]
        [ExcludeFromCodeCoverage]
        public string DefaultSelfPolicy()
        {
            ContentSecurityPolicy policy = new() { DefaultSrc = { ContentSecuritySchemaResources.Self } };
            var header = ContentSecurityHeaderBuilderTests.BuildHeader(policy);
            return header;
        }

        [Benchmark]
        [ExcludeFromCodeCoverage]
        public string ScriptSrcSelfPolicy()
        {
            ContentSecurityPolicy policy = new() { ScriptSrc = { ContentSecuritySchemaResources.Self } };
            var header = ContentSecurityHeaderBuilderTests.BuildHeader(policy);
            return header;
        }

        [Benchmark]
        [ExcludeFromCodeCoverage]
        public string DefaultAndScriptSelfPolicy()
        {
            ContentSecurityPolicy policy = new() { DefaultSrc = { ContentSecuritySchemaResources.Self }, ScriptSrc = { ContentSecuritySchemaResources.Self } };
            var header = ContentSecurityHeaderBuilderTests.BuildHeader(policy);
            return header;
        }
    }
}
