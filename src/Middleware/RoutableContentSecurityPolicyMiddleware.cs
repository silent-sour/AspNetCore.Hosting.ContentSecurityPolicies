using AspNetCore.Hosting.ContentSecurityPolicies.Builders;
using AspNetCore.Hosting.ContentSecurityPolicies.Logging;
using AspNetCore.Hosting.ContentSecurityPolicies.Models;
using AspNetCore.Hosting.ContentSecurityPolicies.Resources;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Middleware
{
    /// <summary>
    /// Middleware for adding a Content Security Policy header to the ASP.NET pipeline, 
    /// with the ability to specify a route for which the policy will be applied.
    /// </summary>
    public class RoutableContentSecurityPolicyMiddleware
    {
        private readonly string _path;
        private protected readonly RequestDelegate _next;
        private protected readonly ILogger<RoutableContentSecurityPolicyMiddleware> _logger;
        private protected readonly string _policyHeader;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentSecurityPolicyMiddleware"/> class.
        /// </summary>
        /// <param name="next">The request delegate.</param>
        /// <param name="policy">The Content Security Policy to apply.</param>
        /// <param name="path">The PathString of the route to apply the policy to</param>
        /// <param name="logger">The logger instance.</param>
        public RoutableContentSecurityPolicyMiddleware(RequestDelegate next,
            ContentSecurityPolicy policy,
            PathString path,
            ILogger<RoutableContentSecurityPolicyMiddleware> logger)
        {
            _policyHeader = ContentSecurityHeaderBuilder.Build(policy);
            _next = next;
            _logger = logger;
            _path = path;
        }

        /// <summary>
        /// Invokes the middleware asynchronously.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        public Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments(_path))
            {
                var added = context.Response.Headers.TryAdd(ContentSecurityPolicyResources.ContentSecurityPolicyHeader, _policyHeader);
                if (!added)
                {
                    ContentSecurityPolicyLogger.CouldNotAddResponseHeader(_logger);
                    throw new InvalidOperationException(ErrorMessages.CouldNotAddHeader);
                }
            }
            return _next.Invoke(context);
        }
    }
}