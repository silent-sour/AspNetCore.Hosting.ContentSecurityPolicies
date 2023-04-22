namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    public class AllowPresentation : SandboxOption
    {
        internal AllowPresentation() { }
        public override string Value { get; internal set; } = "allow-presentation";
    }
}