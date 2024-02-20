using AspNetCore.Hosting.ContentSecurityPolicies.Models.Violations;

using System.Text.Json;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Test.UnitTests
{
    [ExcludeFromCodeCoverage]
    public class CspReportViolationTests
    {
        private const string _violationSample = @"{
  ""csp-report"": {
    ""blocked-uri"": ""http://example.com/css/style.css"",
    ""disposition"": ""report"",
    ""document-uri"": ""http://example.com/signup.html"",
    ""effective-directive"": ""style-src-elem"",
    ""original-policy"": ""default-src 'none'; style-src cdn.example.com; report-to /_/csp-reports"",
    ""referrer"": """",
    ""status-code"": 200,
    ""violated-directive"": ""style-src-elem""
  }
}
";
        private const string _blockedUri = "http://example.com/css/style.css";
        private const string _disposition = "report";
        private const string _documentUri = "http://example.com/signup.html";
        private const string _originalPolicy = "default-src 'none'; style-src cdn.example.com; report-to /_/csp-reports";
        private const string _directive = "style-src-elem";
        private const string _referrer = "";

        private readonly CspReportViolation _reportViolation = new()
        {
            CspReport = new()
            {
                BlockedUri = _blockedUri,
                Disposition = _disposition,
                DocumentUri = _documentUri,
                OriginalPolicy = _originalPolicy,
                StatusCode = 200,
                EffectiveDirective = _directive,
                ViolatedDirective = _directive,
                Referrer = _referrer
            }
        };

        [Fact]
        public void TestParseViolation()
        {
            var data = JsonSerializer.Deserialize<CspReportViolation>(_violationSample);
            Assert.NotNull(data);
            Assert.NotNull(data.CspReport);
            Assert.Equal(200, data.CspReport.StatusCode);
            Assert.Equal("http://example.com/css/style.css", data.CspReport.BlockedUri);
            Assert.Equal("report", data.CspReport.Disposition);

            var test = JsonSerializer.Serialize(_reportViolation);
            var testData = JsonSerializer.Deserialize<CspReportViolation>(test);
            Assert.Equal(testData?.CspReport.OriginalPolicy, data.CspReport.OriginalPolicy);
        }
    }
}
