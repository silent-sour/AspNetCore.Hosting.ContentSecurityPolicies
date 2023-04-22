namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    public class AllowSameOrigin : BaseSandboxOption
    {
        internal AllowSameOrigin() { }
        public override string Value => "allow-same-origin";
    }
}