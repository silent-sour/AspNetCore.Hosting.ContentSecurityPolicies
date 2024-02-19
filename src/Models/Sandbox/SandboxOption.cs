namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    /// <summary>
    /// Base class for sandbox options
    /// </summary>
    public class SandboxOption(string option)
    {
#pragma warning disable S3604 // Member initializer values should not be redundant
        public string Value { get; internal set; } = option;
#pragma warning restore S3604 // Member initializer values should not be redundant
    }
}