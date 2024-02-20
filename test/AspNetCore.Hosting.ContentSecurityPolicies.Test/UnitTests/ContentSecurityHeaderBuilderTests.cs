namespace AspNetCore.Hosting.ContentSecurityPolicies.Test.UnitTests
{
    [ExcludeFromCodeCoverage]
    public class ContentSecurityHeaderBuilderTests
    {
        private const string TestReportUri = "/report-uri";

        [Fact]
        public void TestBuildEmpty()
        {

            ContentSecurityPolicy policy = new();
            var header = BuildHeader(policy);
            Assert.NotEqual(string.Empty, header);
        }

        [Fact]
        public void TestBuildDefaultSrc()
        {

            ContentSecurityPolicy policy = new() { DefaultSrc = { ContentSecuritySchemaResources.Self } };
            Assert.NotEmpty(policy.DefaultSrc);

            var header = BuildHeader(policy);
            Assert.Contains($"{ContentSecurityDirectiveResources.DefaultSrc} {ContentSecuritySchemaResources.Self};", header);
        }

        [Fact]
        public void TestBuildScriptSrc()
        {

            ContentSecurityPolicy policy = new() { ScriptSrc = { ContentSecuritySchemaResources.Self } };
            Assert.NotEmpty(policy.ScriptSrc);

            var header = BuildHeader(policy);
            Assert.Contains($"{ContentSecurityDirectiveResources.ScriptSrc} {ContentSecuritySchemaResources.Self};", header);
        }

        [Fact]
        public void TestBuildStyleSrc()
        {

            ContentSecurityPolicy policy = new() { StyleSrc = { ContentSecuritySchemaResources.Self } };
            Assert.NotEmpty(policy.StyleSrc);

            var header = BuildHeader(policy);
            Assert.Contains($"{ContentSecurityDirectiveResources.StyleSrc} {ContentSecuritySchemaResources.Self};", header);
        }



        [Fact]
        public void TestBuildStyleAttrSrc()
        {

            ContentSecurityPolicy policy = new() { StyleSrcAttr = { ContentSecuritySchemaResources.Self } };
            Assert.NotEmpty(policy.StyleSrcAttr);

            var header = BuildHeader(policy);
            Assert.Contains($"{ContentSecurityDirectiveResources.StyleSrcAttr} {ContentSecuritySchemaResources.Self};", header);
        }



        [Fact]
        public void TestBuildStyleElemSrc()
        {

            ContentSecurityPolicy policy = new() { StyleSrcElem = { ContentSecuritySchemaResources.Self } };
            Assert.NotEmpty(policy.StyleSrcElem);

            var header = BuildHeader(policy);
            Assert.Contains($"{ContentSecurityDirectiveResources.StyleSrcElem} {ContentSecuritySchemaResources.Self};", header);
        }

        [Fact]
        public void TestUpgradeInsecureRequests()
        {
            ContentSecurityPolicy policy = new() { UpgradeInsecureRequests = true };
            Assert.True(policy.UpgradeInsecureRequests);

            var header = BuildHeader(policy);
            Assert.Contains($"{ContentSecurityDirectiveResources.UpgradeInsecureRequests};", header);
        }

        [Fact]
        public void TestSandbox()
        {
            ContentSecurityPolicy policy = new() { Sandbox = SandboxOptions.AllowPopupsToEscapeSandbox };
            Assert.NotNull(policy.Sandbox);
            var header = BuildHeader(policy);
            Assert.Contains($"{ContentSecurityDirectiveResources.Sandbox} {policy.Sandbox.Value};", header);
        }

        [Fact]
        public void TestReportTo()
        {
            ContentSecurityPolicy policy = new() { ReportTo = TestReportUri };
            Assert.NotNull(policy.ReportTo);
            var header = BuildHeader(policy);
            Assert.Contains($"{ContentSecurityDirectiveResources.ReportTo} {policy.ReportTo};", header);
        }

        public static string BuildHeader(ContentSecurityPolicy policy)
        {
            var header = ContentSecurityHeaderBuilder.Build(policy);
            Assert.NotNull(header);
            return header;
        }
    }
}