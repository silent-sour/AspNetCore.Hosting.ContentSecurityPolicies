using AspNetCore.Hosting.ContentSecurityPolicies.Builders;
using AspNetCore.Hosting.ContentSecurityPolicies.Extensions;
using AspNetCore.Hosting.ContentSecurityPolicies.Middleware;
using AspNetCore.Hosting.ContentSecurityPolicies.Resources;

using Microsoft.AspNetCore.TestHost;

using Moq;

using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Test.UnitTests
{
    [ExcludeFromCodeCoverage]
    public class RoutableContentSecurityPoliciesTests
    {
        [Fact]
        public async Task InvokeAsync_AddsCspHeader_WhenRequestMatchesRoute()
        {
            // Arrange
            var path = new PathString("/index.html");
            var policy = new ContentSecurityPolicyBuilder()
                .WithDefaultSource(ContentSecuritySchemaResources.None)
                .BuildPolicy();
            var middleware = new RoutableContentSecurityPolicyMiddleware(
                (innerHttpContext) => Task.CompletedTask,
                policy,
                path,
                Mock.Of<ILogger<RoutableContentSecurityPolicyMiddleware>>()
            );
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Path = path;
            httpContext.Response.Headers.Clear();

            // Act
            await middleware.InvokeAsync(httpContext);

            // Assert
            Assert.True(httpContext.Response.Headers.ContainsKey("Content-Security-Policy"));
            Assert.Equal(ContentSecurityHeaderBuilder.Build(policy), httpContext.Response.Headers.ContentSecurityPolicy);
        }

        [Fact]
        public async Task InvokeAsync_DoesNotAddCspHeader_WhenRequestDoesNotMatchRoute()
        {
            // Arrange
            var path = new PathString("/index.html");
            var policy = new ContentSecurityPolicyBuilder()
                .WithDefaultSource(ContentSecuritySchemaResources.None)
                .BuildPolicy();
            var middleware = new RoutableContentSecurityPolicyMiddleware(
                (innerHttpContext) => Task.CompletedTask,
                policy,
                path,
                Mock.Of<ILogger<RoutableContentSecurityPolicyMiddleware>>()
            );
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Path = "/api/test";
            httpContext.Response.Headers.Clear();

            // Act
            await middleware.InvokeAsync(httpContext);

            // Assert
            Assert.False(httpContext.Response.Headers.ContainsKey("Content-Security-Policy"));
        }

        [Fact]
        public async Task TestNotAdded()
        {
            // Arrange
            var path = new PathString("/index.html");
            var policy = new ContentSecurityPolicyBuilder()
                .WithDefaultSource(ContentSecuritySchemaResources.None)
                .BuildPolicy();
            var middleware = new RoutableContentSecurityPolicyMiddleware(
                (innerHttpContext) => Task.CompletedTask,
                policy,
                path,
                Mock.Of<ILogger<RoutableContentSecurityPolicyMiddleware>>()
            );
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Path = path;
            httpContext.Response.Headers.Clear();

            // Act
            await middleware.InvokeAsync(httpContext);
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await middleware.InvokeAsync(httpContext));

        }

        [Fact]
        public void TestRouteBuilderPattern()
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
                            app.UseRouteSpecificContentSecurityPolicies(new Dictionary<string, Action<ContentSecurityPolicyBuilder>>()
                            {
                                {
                                    "/index.html", policy => policy.WithStyleSource(ContentSecuritySchemaResources.UnsafeInline)
                                }
                            });
                            app.Run(async context =>
                            {
                                await context.Response.WriteAsync("CSP response");
                            });
                        });
                }).Build();
            host.Start();
            Assert.NotNull(host);

            using var server = host.GetTestServer();
            var response = server.CreateRequest("/index.html").SendAsync("GET").Result;
            response.EnsureSuccessStatusCode();
            Assert.Single(response.Headers);
            var header = response.Headers.First();
            var values = header.Value.ToList();
            Assert.Single(values);
            var builder = new StringBuilder();
            builder.Append($" {ContentSecurityDirectiveResources.DefaultSrc} {ContentSecuritySchemaResources.Self};  ");
            builder.Append($"{ContentSecurityDirectiveResources.StyleSrc} {ContentSecuritySchemaResources.UnsafeInline};");
            Assert.Equal(builder.ToString(), values[0]);

            host = new HostBuilder()
                .ConfigureWebHost(webHostBuilder =>
                {
                    webHostBuilder
                        .UseTestServer()
                        .Configure(app =>
                        {
                            app.UseRouteSpecificContentSecurityPolicies(new Dictionary<string, Action<ContentSecurityPolicyBuilder>>()
                            {
                                {
                                    "/index.html", policy => policy.WithStyleSource(ContentSecuritySchemaResources.UnsafeInline)
                                }
                            });
                            app.Run(async context =>
                            {
                                await context.Response.WriteAsync("CSP response");
                            });
                        });
                }).Build();
            Assert.Throws<InvalidOperationException>(() => host.Start());
        }
    }
}
