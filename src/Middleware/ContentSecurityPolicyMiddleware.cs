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

        public Task Invoke(HttpContext context)
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