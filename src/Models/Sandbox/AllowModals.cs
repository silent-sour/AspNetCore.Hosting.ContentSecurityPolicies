namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    public class AllowModals : SandboxOption
    {
        internal AllowModals() { }
        public override string Value { get; internal set; } = "allow-modals";
    }
}