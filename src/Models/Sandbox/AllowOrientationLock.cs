namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    public class AllowOrientationLock : BaseSandboxOption
    {
        internal AllowOrientationLock() { }
        public override string Value => "allow-orientation-lock";
    }
}