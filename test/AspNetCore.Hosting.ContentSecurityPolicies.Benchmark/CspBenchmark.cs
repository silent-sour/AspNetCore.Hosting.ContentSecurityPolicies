using AspNetCore.Hosting.ContentSecurityPolicies.Models;
using AspNetCore.Hosting.ContentSecurityPolicies.Resources;
using AspNetCore.Hosting.ContentSecurityPolicies.Test.UnitTests;

using BenchmarkDotNet.Attributes;

using System.Diagnostics.CodeAnalysis;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Test.Benchmarks
{
    public class CspBenchmark
    {
        protected CspBenchmark()
        {

        }

        [Benchmark]
        [ExcludeFromCodeCoverage]
        public static string DefaultSelfPolicy()
        {
            ContentSecurityPolicy policy = new() { DefaultSrc = { ContentSecuritySchemaResources.Self } };
            var header = ContentSecurityHeaderBuilderTests.BuildHeader(policy);
            return header;
        }

        [Benchmark]
        [ExcludeFromCodeCoverage]
        public static string ScriptSrcSelfPolicy()
        {
            ContentSecurityPolicy policy = new() { ScriptSrc = { ContentSecuritySchemaResources.Self } };
            var header = ContentSecurityHeaderBuilderTests.BuildHeader(policy);
            return header;
        }

        [Benchmark]
        [ExcludeFromCodeCoverage]
        public static string DefaultAndScriptSelfPolicy()
        {
            ContentSecurityPolicy policy = new() { DefaultSrc = { ContentSecuritySchemaResources.Self }, ScriptSrc = { ContentSecuritySchemaResources.Self } };
            var header = ContentSecurityHeaderBuilderTests.BuildHeader(policy);
            return header;
        }
    }
}
