using AspNetCore.Hosting.ContentSecurityPolicies.Builders;
using AspNetCore.Hosting.ContentSecurityPolicies.Logging;
using AspNetCore.Hosting.ContentSecurityPolicies.Models;
using AspNetCore.Hosting.ContentSecurityPolicies.Resources;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Middleware
{
    /// <summary>
    /// Middleware for adding a Content Security Policy header to the ASP.NET pipeline
    /// </summary>
    public class ContentSecurityPolicyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ContentSecurityPolicyMiddleware> _logger;
        private readonly string _policyHeader;

        public ContentSecurityPolicyMiddleware(RequestDelegate next,
            ContentSecurityPolicy policy,
            ILogger<ContentSecurityPolicyMiddleware> logger)
        {
            _policyHeader = ContentSecurityHeaderBuilder.Build(policy);
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Invokes the middleware asynchronously
        /// </summary>
        /// <param name="context">The Http Context</param>
        /// <returns>A Task in which the header is added to the context</returns>
        public Task InvokeAsync(HttpContext context)
        {
            var added = context.Response.Headers.TryAdd(ContentSecurityPolicyResources.ContentSecurityPolicyHeader, _policyHeader);
            if (!added)
            {
                ContentSecurityPolicyLogger.CouldNotAddResponseHeader(_logger);
            }
            return _next.Invoke(context);
        }
    }
}