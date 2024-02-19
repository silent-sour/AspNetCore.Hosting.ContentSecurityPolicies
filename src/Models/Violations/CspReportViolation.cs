using System.Text.Json.Serialization;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Violations
{
    public class CspReportViolation
    {
        [JsonPropertyName("csp-report")]
        public required CspReport CspReport { get; set; }
    }
}
