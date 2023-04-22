namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    public class AllowForms : BaseSandboxOption
    {
        internal AllowForms() { }
        public override string Value => "allow-forms";
    }
}