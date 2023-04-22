namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    public class AllowPointerLock : SandboxOption
    {
        internal AllowPointerLock() { }
        public override string Value { get; internal set; } = "allow-pointer-lock";
    }
}