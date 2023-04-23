using Microsoft.Extensions.Logging;

using System.Diagnostics.CodeAnalysis;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Logging
{
    [ExcludeFromCodeCoverage]
    public static partial class ContentSecurityPolicyLogger
    {
        [LoggerMessage(EventId = 0,
            Message = "Could not add Content Security Policy Header to Response Headers: {message}",
            EventName = "CSP Header Not Added")]
        public static partial void LogCouldNotAddResponseHeader(ILogger logger, LogLevel logLevel, string message);
    }
}