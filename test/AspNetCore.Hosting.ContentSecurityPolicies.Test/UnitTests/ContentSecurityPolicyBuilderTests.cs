namespace AspNetCore.Hosting.ContentSecurityPolicies.Test.UnitTests
{
    [ExcludeFromCodeCoverage]
    public class ContentSecurityPolicyBuilderTests
    {
        [Fact]
        public void TestDefault()
        {
            var builder = new ContentSecurityPolicyBuilder();
            builder.WithChildSource();
            builder.WithConnectSource();
            builder.WithDefaultSource();
            builder.WithFontSource();
            builder.WithFormAction();
            builder.WithFrameAncestors();
            builder.WithFrameSource();
            builder.WithImageSource();
            builder.WithMediaSource();
            builder.WithObjectSource();
            builder.WithScriptAttributeSource();
            builder.WithScriptElementsSource();
            builder.WithScriptSource();
            builder.WithStyleAttributeSource();
            builder.WithStyleElementsSource();
            builder.WithStyleSource();
            var policy = builder.BuildPolicy();
            Assert.NotNull(policy);
        }

        [Fact]
        public void TestDefaultSrc()
        {
            var builder = new ContentSecurityPolicyBuilder(new ContentSecurityPolicy());
            var policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecuritySchemaResources.Self, policy.DefaultSrc);
        }


        [Fact]
        public void TestScriptSrc()
        {
            var builder = new ContentSecurityPolicyBuilder();
            builder.WithScriptSource(ContentSecuritySchemaResources.Self);
            var policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecuritySchemaResources.Self, policy.ScriptSrc);

            builder.WithScriptAttributeSource(ContentSecuritySchemaResources.Self);
            policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecuritySchemaResources.Self, policy.ScriptSrcAttr);

            builder.WithScriptElementsSource(ContentSecuritySchemaResources.Self);
            policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecuritySchemaResources.Self, policy.ScriptSrcElem);
        }


        [Fact]
        public void TestStyleSrc()
        {
            var builder = new ContentSecurityPolicyBuilder();
            builder.WithStyleSource(ContentSecuritySchemaResources.Self);
            var policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecuritySchemaResources.Self, policy.StyleSrc);

            builder.WithStyleAttributeSource(ContentSecuritySchemaResources.Self);
            policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecuritySchemaResources.Self, policy.StyleSrcAttr);

            builder.WithStyleElementsSource(ContentSecuritySchemaResources.Self);
            policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecuritySchemaResources.Self, policy.StyleSrcAttr);
        }

        [Fact]
        public void TestConnectSource()
        {
            var builder = new ContentSecurityPolicyBuilder();
            builder.WithConnectSource(ContentSecuritySchemaResources.Self);
            var policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecuritySchemaResources.Self, policy.ConnectSrc);
        }

        [Fact]
        public void TestMediaSource()
        {
            var builder = new ContentSecurityPolicyBuilder();
            builder.WithImageSource(ContentSecuritySchemaResources.Self);
            var policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecuritySchemaResources.Self, policy.ImgSrc);

            builder.WithMediaSource(ContentSecuritySchemaResources.Self);
            policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecuritySchemaResources.Self, policy.MediaSrc);

            builder.WithObjectSource(ContentSecuritySchemaResources.None);
            policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecuritySchemaResources.None, policy.ObjectSrc);
        }

        [Fact]
        public void TestFontSource()
        {
            var builder = new ContentSecurityPolicyBuilder();
            builder.WithFontSource(ContentSecuritySchemaResources.Self);
            var policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecuritySchemaResources.Self, policy.FontSrc);
        }

        [Fact]
        public void TestFormAction()
        {
            var builder = new ContentSecurityPolicyBuilder();
            builder.WithFormAction(ContentSecuritySchemaResources.Self);
            var policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecuritySchemaResources.Self, policy.FormAction);
        }

        [Fact]
        public void TestFrames()
        {
            var builder = new ContentSecurityPolicyBuilder();
            builder.WithFrameSource(ContentSecuritySchemaResources.None);
            var policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecuritySchemaResources.None, policy.FrameSrc);

            builder.WithFrameAncestors(ContentSecuritySchemaResources.None);
            policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecuritySchemaResources.None, policy.FrameAncestors);

            builder.WithChildSource(ContentSecuritySchemaResources.None);
            policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecuritySchemaResources.None, policy.ChildSrc);
        }

        [Fact]
        public void TestSandbox()
        {
            var builder = new ContentSecurityPolicyBuilder();
            SandboxOption allowScripts = SandboxOptions.AllowScripts;
            builder.WithSandBox(allowScripts);
            var policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Equal(allowScripts, policy.Sandbox);
        }
    }
}
