namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    public class AllowPointerLock : BaseSandboxOption
    {
        internal AllowPointerLock() { }
        public override string Value => "allow-pointer-lock";
    }
}