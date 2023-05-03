using AspNetCore.Hosting.ContentSecurityPolicies.Models;
using AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox;
using AspNetCore.Hosting.ContentSecurityPolicies.Resources;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Builders
{
    /// <summary>
    /// A class using the builder pattern to use for the Content Security Policy middleware
    /// https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy
    /// </summary>
    public sealed class ContentSecurityPolicyBuilder
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ContentSecurityPolicyBuilder()
        {

        }

        /// <summary>
        /// Allows using a base policy
        /// </summary>
        /// <param name="policy"></param>
        public ContentSecurityPolicyBuilder(ContentSecurityPolicy policy)
        {
            Policy = policy;
        }


        internal ContentSecurityPolicy Policy { get; } = new ContentSecurityPolicy();

        /// <summary>
        /// This removes the value of 'self' for the default-src policy.
        /// </summary>
        /// <returns>The builder</returns>
        public ContentSecurityPolicyBuilder WithoutDefaultSelf()
        {
            Policy.DefaultSrc.Remove(ContentSecuritySchemaResources.Self);
            return this;
        }

        /// <summary>
        /// The default-src is the default policy for loading content such as JavaScript, Images, CSS, Font's, AJAX requests, Frames, HTML5 Media.
        /// </summary>
        /// <param name="sources"></param>
        /// <returns>The builder</returns>
        public ContentSecurityPolicyBuilder WithDefaultSource(params string[] sources)
        {
            Policy.DefaultSrc.UnionWith(sources);
            return this;
        }

        /// <summary>
        /// Defines valid sources of JavaScript. 
        /// </summary>
        /// <param name="sources"></param>
        /// <returns>The builder</returns>
        public ContentSecurityPolicyBuilder WithScriptSource(params string[] sources)
        {
            Policy.ScriptSrc.UnionWith(sources);
            return this;
        }

        /// <summary>
        /// Defines valid sources of styles for inline event handlers. 
        /// </summary>
        /// <param name="sources"></param>
        /// <returns>The builder</returns>
        public ContentSecurityPolicyBuilder WithScriptAttributeSource(params string[] sources)
        {
            Policy.ScriptSrcAttr.UnionWith(sources);
            return this;
        }

        /// <summary>
        /// Defines valid sources of styles for script elements. 
        /// </summary>
        /// <param name="souces"></param>
        /// <returns>The builder</returns>
        public ContentSecurityPolicyBuilder WithScriptElementsSource(params string[] sources)
        {
            Policy.ScriptSrcElem.UnionWith(sources);
            return this;
        }

        /// <summary>
        /// Defines valid sources of stylesheets. 
        /// </summary>
        /// <param name="souces"></param>
        /// <returns>The builder</returns>
        public ContentSecurityPolicyBuilder WithStyleSource(params string[] sources)
        {
            Policy.StyleSrc.UnionWith(sources);
            return this;
        }

        /// <summary>
        /// Defines valid sources of styles for inline event handlers. 
        /// </summary>
        /// <param name="souces"></param>
        /// <returns>The builder</returns>
        public ContentSecurityPolicyBuilder WithStyleAttributeSource(params string[] sources)
        {
            Policy.StyleSrcAttr.UnionWith(sources);
            return this;
        }

        /// <summary>
        /// Defines valid sources for stylesheet <style> elements and <link> elements with rel="stylesheet". 
        /// </summary>
        /// <param name="souces"></param>
        /// <returns>The builder</returns>
        public ContentSecurityPolicyBuilder WithStyleElementsSource(params string[] sources)
        {
            Policy.StyleSrcElem.UnionWith(sources);
            return this;
        }

        /// <summary>
        /// Defines valid sources of images. 
        /// </summary>
        /// <param name="sources"></param>
        /// <returns>The builder</returns>
        public ContentSecurityPolicyBuilder WithImageSource(params string[] sources)
        {
            Policy.ImgSrc.UnionWith(sources);
            return this;
        }

        /// <summary>
        /// Applies to XMLHttpRequest (AJAX), WebSocket or EventSource. If not allowed the browser emulates a 400 HTTP status code. 
        /// </summary>
        /// <param name="sources"></param>
        /// <returns>The builder</returns>
        public ContentSecurityPolicyBuilder WithConnectSource(params string[] sources)
        {
            Policy.ConnectSrc.UnionWith(sources);

            return this;
        }

        /// <summary>
        /// Defines valid sources of fonts. 
        /// </summary>
        /// <param name="sources"></param>
        /// <returns>The builder</returns>
        public ContentSecurityPolicyBuilder WithFontSource(params string[] sources)
        {
            Policy.FontSrc.UnionWith(sources);
            return this;
        }

        /// <summary>
        /// Defines valid sources of plugins, eg <object>, <embed> or <applet>. 
        /// </summary>
        /// <param name="sources"></param>
        /// <returns>The builder</returns>
        public ContentSecurityPolicyBuilder WithObjectSource(params string[] sources)
        {
            Policy.ObjectSrc.UnionWith(sources);

            return this;
        }

        /// <summary>
        /// Defines valid sources of audio and video, eg HTML5 <audio>, <video> elements. 
        /// </summary>
        /// <param name="sources"></param>
        /// <returns>The builder</returns>
        public ContentSecurityPolicyBuilder WithMediaSource(params string[] sources)
        {
            Policy.MediaSrc.UnionWith(sources);

            return this;
        }

        /// <summary>
        /// Defines valid sources for web workers and nested browsing contexts loaded using elements such as <frame> and <iframe> 
        /// </summary>
        /// <returns>The builder</returns>
        public ContentSecurityPolicyBuilder WithChildSource(params string[] sources)
        {
            Policy.ChildSrc.UnionWith(sources);

            return this;
        }

        /// <summary>
        /// Defines valid sources that can be used as a HTML <form> action.
        /// </summary>
        /// <param name="sources"></param>
        /// <returns>The builder</returns>
        public ContentSecurityPolicyBuilder WithFormAction(params string[] sources)
        {
            Policy.FormAction.UnionWith(sources);

            return this;
        }

        /// <summary>
        /// Defines valid sources for embedding the resource using <frame> <iframe> <object> <embed> <applet>. Setting this directive to 'none' should be roughly equivalent to X-Frame-Options: DENY 
        /// </summary>
        /// <param name="sources"></param>
        /// <returns>The builder</returns>
        public ContentSecurityPolicyBuilder WithFrameAncestors(params string[] sources)
        {
            Policy.FrameAncestors.UnionWith(sources);

            return this;
        }

        /// <summary>
        /// Defines valid sources for embedding the resource using <frame> <iframe> <object> <embed> <applet>. Setting this directive to 'none' should be roughly equivalent to X-Frame-Options: DENY 
        /// </summary>
        /// <param name="sources"></param>
        /// <returns>The builder</returns>
        public ContentSecurityPolicyBuilder WithFrameSource(params string[] sources)
        {
            Policy.FrameSrc.UnionWith(sources);

            return this;
        }

        /// <summary>
        ///  sandbox directive enables a sandbox for the requested resource similar to the <iframe> sandbox attribute. It applies restrictions to a page's actions including preventing popups, preventing the execution of plugins and scripts, and enforcing a same-origin policy.
        /// </summary>
        /// <param name="sandboxOption"></param>
        /// <returns>The builder</returns>
        public ContentSecurityPolicyBuilder WithSandBox(SandboxOption sandboxOption)
        {
            Policy.Sandbox = sandboxOption;
            return this;
        }

        /// <summary>
        /// Builds the policy
        /// </summary>
        /// <returns>The Content Security Policy</returns>
        public ContentSecurityPolicy BuildPolicy()
        {
            return Policy;
        }
    }
}
