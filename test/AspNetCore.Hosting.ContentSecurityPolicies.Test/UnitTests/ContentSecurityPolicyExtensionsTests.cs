using AspNetCore.Hosting.ContentSecurityPolicies.Builders;
using AspNetCore.Hosting.ContentSecurityPolicies.Extensions;
using AspNetCore.Hosting.ContentSecurityPolicies.Models;
using AspNetCore.Hosting.ContentSecurityPolicies.Resources;

using Microsoft.AspNetCore.TestHost;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Test.UnitTests
{
    public class ContentSecurityPolicyExtensionsTests
    {

        [Fact]
        public async Task Test()
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
                                policy.WithDefaultSource(ContentSecurityPolicyResources.None);
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
        }
    }
}
