namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    public abstract class BaseSandboxOption
    {
        private protected BaseSandboxOption() { }
        public abstract string Value { get; internal set; }
    }
}