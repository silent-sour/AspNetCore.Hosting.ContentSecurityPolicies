using AspNetCore.Hosting.ContentSecurityPolicies.Builders;
using AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox;
using AspNetCore.Hosting.ContentSecurityPolicies.Resources;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Test.UnitTests
{
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
            var builder = new ContentSecurityPolicyBuilder();
            builder.WithDefaultSource(ContentSecurityPolicyResources.Self);
            var policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecurityPolicyResources.Self, policy.DefaultSrc);
        }


        [Fact]
        public void TestScriptSrc()
        {
            var builder = new ContentSecurityPolicyBuilder();
            builder.WithScriptSource(ContentSecurityPolicyResources.Self);
            var policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecurityPolicyResources.Self, policy.ScriptSrc);

            builder.WithScriptAttributeSource(ContentSecurityPolicyResources.Self);
            policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecurityPolicyResources.Self, policy.ScriptSrcAttr);

            builder.WithScriptElementsSource(ContentSecurityPolicyResources.Self);
            policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecurityPolicyResources.Self, policy.ScriptSrcElem);
        }


        [Fact]
        public void TestStyleSrc()
        {
            var builder = new ContentSecurityPolicyBuilder();
            builder.WithStyleSource(ContentSecurityPolicyResources.Self);
            var policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecurityPolicyResources.Self, policy.StyleSrc);

            builder.WithStyleAttributeSource(ContentSecurityPolicyResources.Self);
            policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecurityPolicyResources.Self, policy.StyleSrcAttr);

            builder.WithStyleElementsSource(ContentSecurityPolicyResources.Self);
            policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecurityPolicyResources.Self, policy.StyleSrcAttr);
        }

        [Fact]
        public void TestConnectSource()
        {
            var builder = new ContentSecurityPolicyBuilder();
            builder.WithConnectSource(ContentSecurityPolicyResources.Self);
            var policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecurityPolicyResources.Self, policy.ConnectSrc);
        }

        [Fact]
        public void TestMediaSource()
        {
            var builder = new ContentSecurityPolicyBuilder();
            builder.WithImageSource(ContentSecurityPolicyResources.Self);
            var policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecurityPolicyResources.Self, policy.ImgSrc);

            builder.WithMediaSource(ContentSecurityPolicyResources.Self);
            policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecurityPolicyResources.Self, policy.MediaSrc);

            builder.WithObjectSource(ContentSecurityPolicyResources.None);
            policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecurityPolicyResources.None, policy.ObjectSrc);
        }

        [Fact]
        public void TestFontSource()
        {
            var builder = new ContentSecurityPolicyBuilder();
            builder.WithFontSource(ContentSecurityPolicyResources.Self);
            var policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecurityPolicyResources.Self, policy.FontSrc);
        }

        [Fact]
        public void TestFormAction()
        {
            var builder = new ContentSecurityPolicyBuilder();
            builder.WithFormAction(ContentSecurityPolicyResources.Self);
            var policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecurityPolicyResources.Self, policy.FormAction);
        }

        [Fact]
        public void TestFrames()
        {
            var builder = new ContentSecurityPolicyBuilder();
            builder.WithFrameSource(ContentSecurityPolicyResources.None);
            var policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecurityPolicyResources.None, policy.FrameSrc);

            builder.WithFrameAncestors(ContentSecurityPolicyResources.None);
            policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecurityPolicyResources.None, policy.FrameAncestors);

            builder.WithChildSource(ContentSecurityPolicyResources.None);
            policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Contains(ContentSecurityPolicyResources.None, policy.ChildSrc);
        }

        [Fact]
        public void TestSandbox()
        {
            var builder = new ContentSecurityPolicyBuilder();
            AllowScripts allowScripts = SandboxOptions.AllowScripts;
            builder.WithSandBox(allowScripts);
            var policy = builder.BuildPolicy();
            Assert.NotNull(policy);
            Assert.Equal(allowScripts, policy.Sandbox);
        }
    }
}
