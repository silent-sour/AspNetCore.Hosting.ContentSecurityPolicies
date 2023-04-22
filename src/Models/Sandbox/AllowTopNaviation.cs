namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    public class AllowTopNaviation : BaseSandboxOption
    {
        internal AllowTopNaviation() { }
        public override string Value { get; internal set; } = "allow-top-navigation";
    }
}