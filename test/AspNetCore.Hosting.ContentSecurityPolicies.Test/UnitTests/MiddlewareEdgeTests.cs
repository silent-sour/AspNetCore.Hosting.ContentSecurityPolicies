using AspNetCore.Hosting.ContentSecurityPolicies.Extensions;
using AspNetCore.Hosting.ContentSecurityPolicies.Middleware;

using Microsoft.AspNetCore.TestHost;

using Moq;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Test.UnitTests
{
    [ExcludeFromCodeCoverage]
    public class MiddlewareEdgeTests
    {
        [Fact]
        public async Task TestErrors()
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
            await middlware.InvokeAsync(context.Object);
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await middlware.InvokeAsync(context.Object));
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
                                policy.WithDefaultSource(ContentSecuritySchemaResources.None);
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
