using System.Text.Json.Serialization;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Violations
{
    public class CspReport
    {
        [JsonPropertyName("blocked-uri")]
        public required string BlockedUri { get; set; }
        public required string Disposition { get; set; }
        [JsonPropertyName("document-uri")]
        public required string DocumentUri { get; set; }
        [JsonPropertyName("effective-directive")]
        public required string EffectiveDirective { get; set; }
        [JsonPropertyName("original-policy")]
        public required string OriginalPolicy { get; set; }
        public required string Referrer { get; set; }
        [JsonPropertyName("script-sample")]
        public string? ScriptSample { get; set; }
        [JsonPropertyName("status-code")]
        public required string StatusCode { get; set; }
        [JsonPropertyName("violated-directive")]
        public string ViolatedDirective { get; set; } = string.Empty;
    }
}
