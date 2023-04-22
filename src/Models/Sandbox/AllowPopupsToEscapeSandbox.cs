namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    public class AllowPopupsToEscapeSandbox : BaseSandboxOption
    {
        internal AllowPopupsToEscapeSandbox() { }
        public override string Value => "allow-popups-to-escape-sandbox";
    }
}