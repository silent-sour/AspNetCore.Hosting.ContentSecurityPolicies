# AspNetCore.Hosting.ContentSecurityPolicies
ASP.NET Content Security Middleware

An easy middlware for instituting a Content Security Policy header in the ASP.NET pipeline

Basic Usage:

```csharp
app.UseContentSecurityPolicy(policy => policy
    .WithDefaultSource(ContentSecurityPolicyResources.Self)
    .WithImageSource(ContentSecurityPolicyResources.Self, 
        SchemaResources.Data)
    .WithFontSource(ContentSecurityPolicyResources.Self, 
        ContentSecuritySourceResources.GoogleFonts)
    .WithStyleSource(ContentSecurityPolicyResources.Self, 
        ContentSecuritySourceResources.GoogleFontStyles,
        ContentSecuritySourceResources.Cloudflare)
    .WithScriptSource(ContentSecurityPolicyResources.Self)
    .WithConnectSource(ContentSecurityPolicyResources.Self,
        ContentSecuritySourceResources.MicrosoftLogin,
        ContentSecuritySourceResources.MicrosoftGraph)
    .WithFrameSource(ContentSecurityPolicyResources.None)
    .WithFrameAncestors(ContentSecurityPolicyResources.None)
)
```

References

1. [The Mozilla CSP reference](https://developer.mozilla.org/en-US/docs/Web/HTTP/CSP)
2. [The OWASP cheat sheet](https://cheatsheetseries.owasp.org/cheatsheets/Content_Security_Policy_Cheat_Sheet.html)
3. [The Microsoft Reference](https://learn.microsoft.com/en-us/power-pages/security/manage-content-security-policy)
