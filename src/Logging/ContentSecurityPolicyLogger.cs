using Microsoft.Extensions.Logging;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Logging
{
    /// <summary>
    /// Logger for Add failure
    /// </summary>
    public static partial class ContentSecurityPolicyLogger
    {
        private const string _logMessage = "Could not add Content Security Policy Header to Response Headers.";
        private const string _eventName = "CSP Header Not Added";


        /// <summary>
        /// Logs a message at the Error level indicating that the Content Security Policy header could not be added to the response headers.
        /// </summary>
        /// <param name="logger">The logger instance to use for logging.</param>
        [LoggerMessage(EventId = 0, EventName = _eventName, Level = LogLevel.Error, Message = _logMessage)]
        public static partial void CouldNotAddResponseHeader(ILogger logger);
    }
}