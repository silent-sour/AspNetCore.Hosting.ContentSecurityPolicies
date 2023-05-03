namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    public class AllowTopNavigation : SandboxOption
    {
        internal AllowTopNavigation() { }
        public override string Value { get; internal set; } = "allow-top-navigation";
    }
}