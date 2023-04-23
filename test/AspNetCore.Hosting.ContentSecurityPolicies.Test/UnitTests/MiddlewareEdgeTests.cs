using AspNetCore.Hosting.ContentSecurityPolicies.Builders;
using AspNetCore.Hosting.ContentSecurityPolicies.Extensions;
using AspNetCore.Hosting.ContentSecurityPolicies.Middleware;
using AspNetCore.Hosting.ContentSecurityPolicies.Models;
using AspNetCore.Hosting.ContentSecurityPolicies.Resources;

using Microsoft.AspNetCore.TestHost;

using Moq;

using System.Diagnostics.CodeAnalysis;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Test.UnitTests
{
    public class MiddlewareEdgeTests
    {
        [Fact]
        public void TestErrors()
        {
            Mock<RequestDelegate> requestDelegate = new();
            var policy = new ContentSecurityPolicyBuilder()
                .WithFontSource(ContentSecuritySourceResources.GoogleFonts)
                .WithStyleSource(ContentSecuritySourceResources.GoogleFontStyles)
                .BuildPolicy();
            Mock<ILogger<ContentSecurityPolicyMiddleware>> logger = new();
            var middlware = new ContentSecurityPolicyMiddleware(requestDelegate.Object, policy, logger.Object);
            Assert.NotNull(middlware);
            var context = new Mock<HttpContext>();
            context.Setup(c => c.Request).Returns(new Mock<HttpRequest>().Object);
            var response = new Mock<HttpResponse>();
            response.Setup(r => r.Headers).Returns(new HeaderDictionary());
            context.Setup(c => c.Response).Returns(response.Object);
            middlware.Invoke(context.Object);
            middlware.Invoke(context.Object);
        }

        [Fact]
        [ExcludeFromCodeCoverage]
        public void TestAlreadyAddedMiddleware()
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
                            app.UseContentSecurityPolicy(policy => policy.WithFontSource(ContentSecuritySourceResources.GoogleFonts));
                        });
                }).Build();
            Assert.Throws<InvalidOperationException>(() => host.Start());
            Assert.NotNull(host);
        }
    }
}
