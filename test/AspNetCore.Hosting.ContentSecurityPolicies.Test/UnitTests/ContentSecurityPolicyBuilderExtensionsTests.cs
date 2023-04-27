using AspNetCore.Hosting.ContentSecurityPolicies.Builders;
using AspNetCore.Hosting.ContentSecurityPolicies.Extensions;
using AspNetCore.Hosting.ContentSecurityPolicies.Models;
using AspNetCore.Hosting.ContentSecurityPolicies.Resources;

using Microsoft.AspNetCore.TestHost;

using System.Diagnostics.CodeAnalysis;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Test.UnitTests
{
    [ExcludeFromCodeCoverage]
    public class ContentSecurityPolicyBuilderExtensionsTests
    {
        [Fact]
        public async Task TestBuilderPattern()
        {
            var currentPolicy = new ContentSecurityPolicy();
            var host = new HostBuilder()
                .ConfigureWebHost(webHostBuilder =>
                {
                    webHostBuilder
                        .UseTestServer()
                        .Configure(app =>
                        {

                            app.UseContentSecurityPolicy(policy =>
                            {
                                policy.WithDefaultSource(ContentSecuritySchemaResources.None);
                                currentPolicy = policy.BuildPolicy();
                            });
                            app.Run(async context =>
                            {
                                await context.Response.WriteAsync("CSP response");
                            });
                        });
                }).Build();
            await host.StartAsync();
            Assert.NotNull(host);

            using var server = host.GetTestServer();
            var response = await server.CreateRequest("/").SendAsync("PUT");
            response.EnsureSuccessStatusCode();
            Assert.Single(response.Headers);

            var expected = ContentSecurityHeaderBuilder.Build(currentPolicy);
            Assert.Equal(expected, response.Headers.GetValues(ContentSecurityPolicyResources.ContentSecurityPolicyHeader).Single());

            host = new HostBuilder()
                .ConfigureWebHost(webHostBuilder =>
                {
                    webHostBuilder
                        .UseTestServer()
                        .Configure(app =>
                        {
                            app.UseContentSecurityPolicy(policyBuilder =>
                            {
                                policyBuilder.WithDefaultSource(ContentSecuritySchemaResources.None);
                            });
                            app.UseContentSecurityPolicy(builder => builder.WithDefaultSource(currentPolicy.DefaultSrc.ToArray()));
                            app.Run(async context =>
                            {
                                await context.Response.WriteAsync("CSP response");
                            });
                        });
                }).Build();
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await host.StartAsync());
        }
    }
}
