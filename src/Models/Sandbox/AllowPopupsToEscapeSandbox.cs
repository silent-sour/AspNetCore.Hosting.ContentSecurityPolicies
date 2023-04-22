namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    public class AllowPopupsToEscapeSandbox : SandboxOption
    {
        internal AllowPopupsToEscapeSandbox() { }
        public override string Value { get; internal set; } = "allow-popups-to-escape-sandbox";
    }
}