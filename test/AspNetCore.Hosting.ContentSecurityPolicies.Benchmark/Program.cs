using AspNetCore.Hosting.ContentSecurityPolicies.Test.Benchmarks;

using BenchmarkDotNet.Running;

BenchmarkRunner.Run<CspBenchmark>();