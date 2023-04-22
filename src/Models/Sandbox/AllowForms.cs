namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    public class AllowForms : SandboxOption
    {
        internal AllowForms() { }
        public override string Value { get; internal set; } = "allow-forms";
    }
}