using AspNetCore.Hosting.ContentSecurityPolicies.Extensions;
using AspNetCore.Hosting.ContentSecurityPolicies.Middleware;

using Microsoft.AspNetCore.TestHost;
using Microsoft.Net.Http.Headers;

using Moq;

using System.Text;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Test.UnitTests
{
    [ExcludeFromCodeCoverage]

    public class ReportOnlyContentSecurityPolicyTests
    {
        [Fact]
        public async Task TestRouteBuilderPatternAsync()
        {
            var host = Mock.Of<HostBuilder>()
                .ConfigureWebHost(webHostBuilder =>
                {
                    webHostBuilder
                        .UseTestServer()
                        .Configure(app =>
                        {
                            // This is to reset the middleware added flag to allow multiple tests with adds
                            ContentSecurityPolicyExtensions.ResetMiddlewareAdded();
                            app.UseReportOnlyContentSecurityPolicy(reportTo: string.Empty, policy => policy.WithReportTo(string.Empty));
                            app.Run(async context =>
                            {
                                await context.Response.WriteAsync("CSP response");
                            });
                        });
                }).Build();
            Assert.Throws<InvalidOperationException>(() => host.Start());


            host = Mock.Of<HostBuilder>()
                .ConfigureWebHost(webHostBuilder =>
                {
                    webHostBuilder
                        .UseTestServer()
                        .Configure(app =>
                        {
                            // This is to reset the middleware added flag to allow multiple tests with adds
                            ContentSecurityPolicyExtensions.ResetMiddlewareAdded();
                            app.UseReportOnlyContentSecurityPolicy(reportTo: "/report-uri");
                            app.Run(async context =>
                            {
                                await context.Response.WriteAsync("CSP response");
                            });
                        });
                }).Build();
            await host.StartAsync();
            Assert.NotNull(host);

            using var server = host.GetTestServer();
            var response = await server.CreateRequest("/index.html").SendAsync("GET");
            response.EnsureSuccessStatusCode();
            Assert.Single(response.Headers);
            var header = response.Headers.First();
            var values = header.Value.ToList();
            Assert.Single(values);
            var builder = new StringBuilder();
            builder.Append($" {ContentSecurityDirectiveResources.DefaultSrc} {ContentSecuritySchemaResources.Self};");
            builder.Append($" {ContentSecurityDirectiveResources.ReportTo} /report-uri;");
            Assert.Equal(builder.ToString(), values[0]);

            host = new HostBuilder()
                .ConfigureWebHost(webHostBuilder =>
                {
                    webHostBuilder
                        .UseTestServer()
                        .Configure(app =>
                        {
                            app.UseReportOnlyContentSecurityPolicy("/report-uri");
                            app.Run(async context =>
                            {
                                await context.Response.WriteAsync("CSP response");
                            });
                        });
                }).Build();
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await host.StartAsync());
        }

        [Fact]
        public void TestNotAdded()
        {
            // Arrange
            var path = new PathString("/index.html");
            var policy = new ContentSecurityPolicyBuilder()
                .WithDefaultSource(ContentSecuritySchemaResources.None)
                .BuildPolicy();
            Assert.Throws<InvalidOperationException>(() =>
            {
                _ = new ReportOnlyContentSecurityPolicyMiddleware(
                    (innerHttpContext) => Task.CompletedTask,
                    policy,
                    Mock.Of<ILogger<ReportOnlyContentSecurityPolicyMiddleware>>()
                );
            });
        }

        [Fact]
        public async Task InvokeAsync_AddsCspHeader_WhenRequestMatchesRoute()
        {
            // Arrange
            var path = new PathString("/index.html");
            var policy = new ContentSecurityPolicyBuilder()
                .WithDefaultSource(ContentSecuritySchemaResources.None)
                .WithReportTo("/report-uri")
                .BuildPolicy();
            var middleware = new ReportOnlyContentSecurityPolicyMiddleware(
                (innerHttpContext) => Task.CompletedTask,
                policy,
                Mock.Of<ILogger<ReportOnlyContentSecurityPolicyMiddleware>>()
            );
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Path = path;
            httpContext.Response.Headers.Clear();

            // Act
            await middleware.InvokeAsync(httpContext);

            // Assert
            Assert.True(httpContext.Response.Headers.ContainsKey(HeaderNames.ContentSecurityPolicyReportOnly));
        }
    }
}
