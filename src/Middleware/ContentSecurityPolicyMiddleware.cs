using AspNetCore.Hosting.ContentSecurityPolicies.Builders;
using AspNetCore.Hosting.ContentSecurityPolicies.Models;
using AspNetCore.Hosting.ContentSecurityPolicies.Resources;

using Microsoft.AspNetCore.Http;

using System;
using System.Threading.Tasks;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Middleware
{
    public class ContentSecurityPolicyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _policy;

        public ContentSecurityPolicyMiddleware(RequestDelegate next, ContentSecurityPolicy policy)
        {
            if (policy == null)
                throw new ArgumentNullException(nameof(policy));
            _policy = ContentSecurityHeaderBuilder.Build(policy);
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            context.Response.Headers[ContentSecurityPolicyResources.ContentSecurityPolicyHeader] = _policy;
            return _next?.Invoke(context) ?? Task.CompletedTask;
        }
    }
}