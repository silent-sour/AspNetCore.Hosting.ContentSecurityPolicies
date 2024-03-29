﻿using AspNetCore.Hosting.ContentSecurityPolicies.Builders;
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
    /// Middleware for adding a Content Security Policy header to the ASP.NET pipeline, 
    /// with the ability to specify a route for which the policy will be applied.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of the <see cref="ContentSecurityPolicyMiddleware"/> class.
    /// </remarks>
    /// <param name="next">The request delegate.</param>
    /// <param name="policy">The Content Security Policy to apply.</param>
    /// <param name="path">The PathString of the route to apply the policy to</param>
    /// <param name="logger">The logger instance.</param>
    public class RoutableContentSecurityPolicyMiddleware(RequestDelegate next,
        ContentSecurityPolicy policy,
        PathString path,
        ILogger<RoutableContentSecurityPolicyMiddleware> logger)
    {
        private readonly string _path = path;
        private protected readonly RequestDelegate _next = next;
        private protected readonly ILogger<RoutableContentSecurityPolicyMiddleware> _logger = logger;
        private protected readonly string _policyHeader = ContentSecurityHeaderBuilder.Build(policy);

        /// <summary>
        /// Invokes the middleware asynchronously.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        public Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments(_path))
            {
                var added = context.Response.Headers.TryAdd(HeaderNames.ContentSecurityPolicy, _policyHeader);
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