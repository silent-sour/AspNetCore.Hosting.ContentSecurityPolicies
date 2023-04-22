namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    public class AllowScripts : BaseSandboxOption
    {
        internal AllowScripts() { }
        public override string Value => "allow-scripts";
    }
}