using AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox;
using AspNetCore.Hosting.ContentSecurityPolicies.Resources;

using System.Collections.Generic;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Models
{
    public class ContentSecurityPolicy
    {
        /// <summary>
        /// Default Constructor.
        /// Uses 'self' as the default policy source
        /// </summary>
        public ContentSecurityPolicy() : this(ContentSecurityPolicyResources.Self)
        {
        }


        /// <summary>
        /// Allows a CDN to be set as the default policy source
        /// </summary>
        /// <param name="cdnBasePath"></param>
        public ContentSecurityPolicy(string cdnBasePath)
        {
            DefaultSrc.Add(cdnBasePath);
        }

        /// <summary>
        /// Defines valid sources for web workers and nested browsing contexts loaded using elements such as <frame> and <iframe> 
        /// </summary>
        public HashSet<string> ChildSrc { get; set; } = new HashSet<string>();
        /// <summary>
        /// Applies to XMLHttpRequest (AJAX), WebSocket or EventSource. If not allowed the browser emulates a 400 HTTP status code. 
        /// </summary>
        public HashSet<string> ConnectSrc { get; set; } = new HashSet<string>();
        /// <summary>
        /// The default-src is the default policy for loading content such as JavaScript, Images, CSS, Font's, AJAX requests, Frames, HTML5 Media.
        /// </summary>
        public HashSet<string> DefaultSrc { get; set; } = new HashSet<string>();
        /// <summary>
        /// Defines valid sources of fonts. 
        /// </summary>
        public HashSet<string> FontSrc { get; set; } = new HashSet<string>();
        /// <summary>
        /// Defines valid sources of images. 
        /// </summary>
        /// <summary>
        /// Defines valid sources that can be used as a HTML <form> action.
        /// </summary>
        public HashSet<string> FormAction { get; set; } = new HashSet<string>();

        /// <summary>
        /// Defines valid sources for embedding the resource using <frame> <iframe> <object> <embed> <applet>. 
        /// Setting this directive to 'none' should be roughly equivalent to X-Frame-Options: DENY 
        /// </summary>
        public HashSet<string> FrameAncestors { get; set; } = new HashSet<string>();

        /// <summary>
        /// Specifies valid sources for nested browsing contexts loading using elements such as <frame> and <iframe>.
        /// </summary>
        public HashSet<string> FrameSrc { get; set; } = new HashSet<string>();
        /// <summary>
        /// Specifies valid sources of images and favicons.
        /// </summary>
        public HashSet<string> ImgSrc { get; set; } = new HashSet<string>();
        /// <summary>
        /// Specifies valid sources of application manifest files.
        /// </summary>
        public HashSet<string> ManifestSrc { get; set; } = new HashSet<string>();
        /// <summary>
        /// Defines valid sources of audio and video, eg HTML5 <audio>, <video> elements. 
        /// </summary>
        public HashSet<string> MediaSrc { get; set; } = new HashSet<string>();
        /// <summary>
        /// Defines valid sources of stylesheets. 
        /// </summary>
        public HashSet<string> StyleSrc { get; set; } = new HashSet<string>();
        /// <summary>
        /// Defines valid sources for inline styles applied to individual DOM elements. 
        /// </summary>
        public HashSet<string> StyleSrcAttr { get; set; } = new HashSet<string>();
        /// <summary>
        /// Defines valid sources for stylesheet <style> elements and <link> elements with rel="stylesheet".
        /// </summary>
        public HashSet<string> StyleSrcElem { get; set; } = new HashSet<string>();
        /// <summary>
        /// Defines valid sources of JavaScript. 
        /// </summary>
        public HashSet<string> ScriptSrc { get; set; } = new HashSet<string>();
        /// <summary>
        /// Defines valid sources for JavaScript inline event handlers.
        /// </summary>
        public HashSet<string> ScriptSrcAttr { get; set; } = new HashSet<string>();
        /// <summary>
        /// Defines valid sources for JavaScript <script> elements.
        /// </summary>
        public HashSet<string> ScriptSrcElem { get; set; } = new HashSet<string>();
        /// <summary>
        /// Defines valid sources of plugins, eg <object>, <embed> or <applet>. 
        /// </summary>
        public HashSet<string> ObjectSrc { get; set; } = new HashSet<string>();

        /// <summary>
        /// The HTTP Content-Security-Policy (CSP) sandbox directive enables a sandbox for the requested resource 
        /// similar to the <iframe> sandbox attribute. It applies restrictions to a page's actions including 
        /// preventing popups, preventing the execution of plugins and scripts, and enforcing a same-origin policy.
        /// </summary>
        public BaseSandboxOption? Sandbox { get; set; }

        /// <summary>
        /// The HTTP Content-Security-Policy (CSP) upgrade-insecure-requests directive instructs user agents to 
        /// treat all of a site's insecure URLs (those served over HTTP) as though they have been replaced with secure URLs (those served over HTTPS). 
        /// This directive is intended for web sites with large numbers of insecure legacy URLs that need to be rewritten.
        /// </summary>
        public bool UpgradeInsecureRequests { get; set; }

        /// <summary>
        /// Defines valid sources for Worker, SharedWorker, or ServiceWorker scripts
        /// </summary>
        public HashSet<string> WorkerSrc { get; set; } = new HashSet<string>();
    }
}
