namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    public class AllowScripts : SandboxOption
    {
        internal AllowScripts() { }
        public override string Value { get; internal set; } = "allow-scripts";
    }
}