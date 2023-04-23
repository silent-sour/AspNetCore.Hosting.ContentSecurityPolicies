using Microsoft.Extensions.Logging;

using System.Diagnostics.CodeAnalysis;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Logging
{
    [ExcludeFromCodeCoverage]
    public static partial class ContentSecurityPolicyLogger
    {
        private const string _logMessage = "Could not add Content Security Policy Header to Response Headers.";
        private const string _eventName = "CSP Header Not Added";


        [LoggerMessage(EventId = 0, EventName = _eventName, Level = LogLevel.Error, Message = _logMessage)]
        public static partial void CouldNotAddResponseHeader(ILogger logger);
    }
}