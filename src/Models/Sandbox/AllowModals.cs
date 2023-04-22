namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    public class AllowModals : BaseSandboxOption
    {
        internal AllowModals() { }
        public override string Value => "allow-modals";
    }
}