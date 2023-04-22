namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    public class AllowPopups : SandboxOption
    {
        internal AllowPopups() { }
        public override string Value { get; internal set; } = "allow-popups";
    }
}