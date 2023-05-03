namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    public abstract class SandboxOption
    {
        private protected SandboxOption() { }
        public abstract string Value { get; internal set; }
    }
}