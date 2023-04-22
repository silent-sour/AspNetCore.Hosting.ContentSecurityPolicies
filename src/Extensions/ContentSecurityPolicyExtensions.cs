using AspNetCore.Hosting.ContentSecurityPolicies.Builders;
using AspNetCore.Hosting.ContentSecurityPolicies.Middleware;

using Microsoft.AspNetCore.Builder;

using System;
using System.Diagnostics.CodeAnalysis;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Extensions
{
    public static class ContentSecurityPolicyExtensions
    {
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
            var builder = new ContentSecurityPolicyBuilder();
            configurePolicy(builder);
            return app.UseMiddleware<ContentSecurityPolicyMiddleware>(builder.BuildPolicy());
        }
    }
}
