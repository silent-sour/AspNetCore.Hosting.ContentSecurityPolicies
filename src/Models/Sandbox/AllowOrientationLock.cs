namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    public class AllowOrientationLock : SandboxOption
    {
        internal AllowOrientationLock() { }
        public override string Value { get; internal set; } = "allow-orientation-lock";
    }
}