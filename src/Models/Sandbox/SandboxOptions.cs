using AspNetCore.Hosting.ContentSecurityPolicies.Resources;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    /// <summary>
    /// Helper class to define sandbox options
    /// </summary>
    public static class SandboxOptions
    {
        /// <summary>
        /// Allows the embedded browsing context to submit forms. If this keyword is not used, this operation is not allowed.
        /// </summary>
        public static SandboxOption AllowForms { get; set; } = new SandboxOption(ContentSecuritySandboxResources.AllowForms);
        /// <summary>
        /// Allows the embedded browsing context to open modal windows.
        /// </summary>
        public static SandboxOption AllowModals { get; set; } = new SandboxOption(ContentSecuritySandboxResources.AllowModals);
        /// <summary>
        /// Allows the embedded browsing context to disable the ability to lock the screen orientation.
        /// </summary>
        public static SandboxOption AllowOrientationLock { get; set; } = new SandboxOption(ContentSecuritySandboxResources.AllowOrientationLock);
        /// <summary>
        /// Allows the embedded browsing context to use the <a href="https://developer.mozilla.org/en-US/docs/Web/API/Pointer_Lock_API">Pointer Lock API</a>
        /// </summary>
        public static SandboxOption AllowPointerLock { get; set; } = new SandboxOption(ContentSecuritySandboxResources.AllowPointerLock);

        /// <summary>
        /// Allows popups (like from window.open, target="_blank", showModalDialog). If this keyword is not used, that functionality will silently fail.
        /// </summary>
        public static SandboxOption AllowPopups { get; set; } = new SandboxOption(ContentSecuritySandboxResources.AllowPopups);
        /// <summary>
        /// Allows a sandboxed document to open new windows without forcing the sandboxing flags upon them. This will allow, for example, a third-party advertisement to be safely sandboxed without forcing the same restrictions upon a landing page.
        /// </summary>
        public static SandboxOption AllowPopupsToEscapeSandbox { get; set; } = new SandboxOption(ContentSecuritySandboxResources.AllowPopupsToEscapeSandbox);
        /// <summary>
        /// Allows embedders to have control over whether an iframe can start a presentation session.
        /// </summary>
        public static SandboxOption AllowPresentation { get; set; } = new SandboxOption(ContentSecuritySandboxResources.AllowPresentation);
        /// <summary>
        /// Allows the content to be treated as being from its normal origin. If this keyword is not used, the embedded content is treated as being from a unique origin.
        /// </summary>
        public static SandboxOption AllowSameOrigin { get; set; } = new SandboxOption(ContentSecuritySandboxResources.AllowSameOrigin);
        /// <summary>
        /// Allows the embedded browsing context to run scripts (but not create pop-up windows). If this keyword is not used, this operation is not allowed.
        /// </summary>
        public static SandboxOption AllowScripts { get; set; } = new SandboxOption(ContentSecuritySandboxResources.AllowScripts);
        /// <summary>
        /// Allows the embedded browsing context to navigate (load) content to the top-level browsing context. If this keyword is not used, this operation is not allowed.
        /// </summary>
        public static SandboxOption AllowTopNavigation { get; set; } = new SandboxOption(ContentSecuritySandboxResources.AllowTopNavigation);
    }
}