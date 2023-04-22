using System.Linq;

namespace AspNetCore.Hosting.ContentSecurityPolicies.Models.Sandbox
{
    public class SandboxOption: BaseSandboxOption
    {
        public SandboxOption() { }
        public override string Value { get; internal set; } = string.Empty;
        public void Merge(BaseSandboxOption other)
        {
            var values = Value.Split(' ');
            var otherValues = other.Value.Split(' ');
            Value = string.Join(' ', values.Union(otherValues));
        }
    }
}