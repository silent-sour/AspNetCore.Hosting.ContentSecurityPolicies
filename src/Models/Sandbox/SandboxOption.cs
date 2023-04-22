namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    public static class SandboxOption
    {
        /// <summary>
        /// Allows the embedded browsing context to submit forms. If this keyword is not used, this operation is not allowed.
        /// </summary>
        public static AllowForms AllowForms { get; set; } = new AllowForms();
        /// <summary>
        /// Allows the embedded browsing context to open modal windows.
        /// </summary>
        public static AllowModals AllowModals { get; set; } = new AllowModals();
        /// <summary>
        /// Allows the embedded browsing context to disable the ability to lock the screen orientation.
        /// </summary>
        public static AllowOrientationLock AllowOrientationLock { get; set; } = new AllowOrientationLock();
        /// <summary>
        /// Allows the embedded browsing context to use the <a href="https://developer.mozilla.org/en-US/docs/Web/API/Pointer_Lock_API">Pointer Lock API</a>
        /// </summary>
        public static AllowPointerLock AllowPointerLock { get; set; } = new AllowPointerLock();

        /// <summary>
        /// Allows popups (like from window.open, target="_blank", showModalDialog). If this keyword is not used, that functionality will silently fail.
        /// </summary>
        public static AllowPopups AllowPopups { get; set; } = new AllowPopups();
        /// <summary>
        /// Allows a sandboxed document to open new windows without forcing the sandboxing flags upon them. This will allow, for example, a third-party advertisement to be safely sandboxed without forcing the same restrictions upon a landing page.
        /// </summary>
        public static AllowPopupsToEscapeSandbox AllowPopupsToEscapeSandbox { get; set; } = new AllowPopupsToEscapeSandbox();
        /// <summary>
        /// Allows embedders to have control over whether an iframe can start a presentation session.
        /// </summary>
        public static AllowPresentation AllowPresentation { get; set; } = new AllowPresentation();
        /// <summary>
        /// Allows the content to be treated as being from its normal origin. If this keyword is not used, the embedded content is treated as being from a unique origin.
        /// </summary>
        public static AllowSameOrigin AllowSameOrigin { get; set; } = new AllowSameOrigin();
        /// <summary>
        /// Allows the embedded browsing context to run scripts (but not create pop-up windows). If this keyword is not used, this operation is not allowed.
        /// </summary>
        public static AllowScripts AllowScripts { get; set; } = new AllowScripts();
        /// <summary>
        /// Allows the embedded browsing context to navigate (load) content to the top-level browsing context. If this keyword is not used, this operation is not allowed.
        /// </summary>
        public static AllowTopNaviation AllowTopNaviation { get; set; } = new AllowTopNaviation();
    }
}