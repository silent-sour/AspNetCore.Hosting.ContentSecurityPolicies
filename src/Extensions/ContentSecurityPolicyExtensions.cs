using AspNetCore.Hosting.ContentSecurityPolicies.Builders;
using AspNetCore.Hosting.ContentSecurityPolicies.Middleware;

using Microsoft.AspNetCore.Builder;

using System;
using System.Diagnostics.CodeAnalysis;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Extensions
{
    /// <summary>
    /// Extension Method for IApplicationBuilder to add the Content Security Policy Middleware
    /// </summary>
    public static class ContentSecurityPolicyExtensions
    {
        /// <summary>
        /// Static field to enforce that the middleware is only activated once
        /// </summary>
        private static bool _middlewareAdded;

        /// <summary>
        /// The HTTP Content-Security-Policy response header allows web site administrators to control resources the user agent is allowed to load for a given page. With a few exceptions, policies mostly involve specifying server origins and script endpoints. This helps guard against cross-site scripting attacks
        /// </summary>
        /// <param name="app"></param>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseContentSecurityPolicy(
            [NotNull] this IApplicationBuilder app,
            [NotNull] Action<ContentSecurityPolicyBuilder> configurePolicy)
        {
            if (_middlewareAdded)
            {
                throw new InvalidOperationException("Content Security Policy Middleware has already been added.");
            }
            _middlewareAdded = true;
            var builder = new ContentSecurityPolicyBuilder();
            configurePolicy(builder);
            return app.UseMiddleware<ContentSecurityPolicyMiddleware>(builder.BuildPolicy());
        }
    }
}
