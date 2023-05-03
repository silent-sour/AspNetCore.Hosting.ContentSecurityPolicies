namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    /// <summary>
    /// Base class for sandbox options
    /// </summary>
    public class SandboxOption
    {
        public SandboxOption(string option)
        {
            Value = option;
        }
        public string Value { get; internal set; }
    }
}