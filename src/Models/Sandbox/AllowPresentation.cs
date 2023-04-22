namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    public class AllowPresentation : BaseSandboxOption
    {
        internal AllowPresentation() { }
        public override string Value => "allow-presentation";
    }
}