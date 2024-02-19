using AspNetCore.Hosting.ContentSecurityPolicies.Builders;
using AspNetCore.Hosting.ContentSecurityPolicies.Logging;
using AspNetCore.Hosting.ContentSecurityPolicies.Models;
using AspNetCore.Hosting.ContentSecurityPolicies.Resources;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Middleware
{
    /// <summary>
    /// Middleware for adding a Content Security Policy header to the ASP.NET pipeline
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ContentSecurityPolicyMiddleware"/> class.
    /// </remarks>
    /// <param name="next">The request delegate.</param>
    /// <param name="policy">The Content Security Policy to apply.</param>
    /// <param name="logger">The logger instance.</param>
    public class ContentSecurityPolicyMiddleware(RequestDelegate next,
        ContentSecurityPolicy policy,
        ILogger<ContentSecurityPolicyMiddleware> logger)
    {
        private protected readonly RequestDelegate _next = next;
        private protected readonly ILogger<ContentSecurityPolicyMiddleware> _logger = logger;
        private protected readonly string _policyHeader = ContentSecurityHeaderBuilder.Build(policy);

        /// <summary>
        /// Invokes the middleware asynchronously.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <returns>A <see cref="Task"/> in which the header is added to the context.</returns>
        public Task InvokeAsync(HttpContext context)
        {
            var added = context.Response.Headers.TryAdd(HeaderNames.ContentSecurityPolicy, _policyHeader);
            if (!added)
            {
                ContentSecurityPolicyLogger.CouldNotAddResponseHeader(_logger);
                throw new InvalidOperationException(ErrorMessages.CouldNotAddHeader);
            }
            return _next.Invoke(context);
        }
    }
}