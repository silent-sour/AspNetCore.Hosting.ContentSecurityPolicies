using System.Text.Json.Serialization;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Violations
{
    public class CspReport
    {
        [JsonPropertyName("blocked-uri")]
        public required string BlockedUri { get; set; }
        [JsonPropertyName("disposition")]
        public string Disposition { get; set; } = string.Empty;
        [JsonPropertyName("document-uri")]
        public required string DocumentUri { get; set; }
        [JsonPropertyName("effective-directive")]
        public string EffectiveDirective { get; set; } = string.Empty;
        [JsonPropertyName("original-policy")]
        public required string OriginalPolicy { get; set; }
        [JsonPropertyName("referrer")]
        public string Referrer { get; set; } = string.Empty;
        [JsonPropertyName("script-sample")]
        public string ScriptSample { get; set; } = string.Empty;
        [JsonPropertyName("status-code")]
        public required byte StatusCode { get; set; }
        [JsonPropertyName("violated-directive")]
        public string ViolatedDirective { get; set; } = string.Empty;
    }
}
