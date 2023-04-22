namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    public class AllowPopups : BaseSandboxOption
    {
        internal AllowPopups() { }
        public override string Value => "allow-popups";
    }
}