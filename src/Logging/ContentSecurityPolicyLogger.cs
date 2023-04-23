using Microsoft.Extensions.Logging;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Logging
{
    public static partial class ContentSecurityPolicyLogger
    {
        [LoggerMessage(EventId = 0,
            Message = "Could not add Content Security Policy Header to Response Headers",
            EventName = "CSP Header Not Added")]
        public static partial void LogCouldNotAddResponseHeader(ILogger logger, LogLevel logLevel);
    }
}