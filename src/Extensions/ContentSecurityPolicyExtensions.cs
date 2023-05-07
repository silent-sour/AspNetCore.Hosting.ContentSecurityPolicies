using AspNetCore.Hosting.ContentSecurityPolicies.Builders;
using AspNetCore.Hosting.ContentSecurityPolicies.Middleware;
using AspNetCore.Hosting.ContentSecurityPolicies.Resources;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Extensions
{
    /// <summary>
    /// Extension Method for <see cref="IApplicationBuilder"/> to add the Content Security Policy Middleware.
    /// </summary>
    public static class ContentSecurityPolicyExtensions
    {
        /// <summary>
        /// Static field to enforce that the middleware is only activated once
        /// </summary>
        private static bool _middlewareAdded;

        /// <summary>
        /// Adds a Content Security Policy Middleware to the pipeline with the specified policy configuration.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> instance.</param>
        /// <param name="configurePolicy">A delegate that configures the <see cref="ContentSecurityPolicyBuilder"/>.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> instance.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the middleware has already been added to the pipeline.</exception>

        public static IApplicationBuilder UseContentSecurityPolicy(
            [NotNull] this IApplicationBuilder app,
            [NotNull] Action<ContentSecurityPolicyBuilder> configurePolicy)
        {
            if (_middlewareAdded)
            {
                throw new InvalidOperationException(ErrorMessages.MiddlewareAlreadyAdded);
            }
            _middlewareAdded = true;
            var builder = new ContentSecurityPolicyBuilder();
            configurePolicy(builder);
            return app.UseMiddleware<ContentSecurityPolicyMiddleware>(builder.BuildPolicy());
        }

        /// <summary>
        /// Adds a route-specific Content Security Policy Middleware to the pipeline with the specified policy configuration.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> instance.</param>
        /// <param name="routes">A dictionary containing the path and policy configuration for each route.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> instance.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the middleware has already been added to the pipeline.</exception>
        public static IApplicationBuilder UseRouteSpecificContentSecurityPolicies(
            [NotNull] this IApplicationBuilder app,
            [NotNull] Dictionary<string, Action<ContentSecurityPolicyBuilder>> routes)
        {
            if (_middlewareAdded)
            {
                throw new InvalidOperationException(ErrorMessages.MiddlewareAlreadyAdded);
            }
            _middlewareAdded = true;
            var builder = new ContentSecurityPolicyBuilder();
            foreach (var route in routes)
            {
                var path = route.Key;
                var configure = route.Value;
                configure(builder);

                app.UseMiddleware<RoutableContentSecurityPolicyMiddleware>(builder.BuildPolicy(), new PathString(path));
            }

            return app;
        }

        /// <summary>
        /// For testing harness to reset the flag
        /// </summary>
        internal static void ResetMiddlewareAdded()
        {
            _middlewareAdded = false;
        }
    }
}
