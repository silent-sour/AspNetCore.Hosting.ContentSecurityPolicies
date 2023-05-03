namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    public class AllowSameOrigin : SandboxOption
    {
        internal AllowSameOrigin() { }
        public override string Value { get; internal set; } = "allow-same-origin";
    }
}