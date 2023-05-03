# AspNetCore.Hosting.ContentSecurityPolicies
ASP.NET Content Security Middleware

An easy middlware for instituting a Content Security Policy header in the ASP.NET pipeline

Basic use case (includes 'self' for default-src):

```csharp
    app.UseContentSecurityPolicy(policy => policy);
```

Standard use case:

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
        .WithFrameAncestors(ContentSecurityPolicyResources.None);
)
```

Disable default-src 'self':

```csharp
    app.UseContentSecurityPolicy(policy => policy.WithoutDefaultSelf());
```

Use sandbox:
```csharp
    app.UseContentSecurityPolicy(policy => policy.WithSandBox(SandboxOptions.AllowScripts))
```

References

1. [The Mozilla CSP reference](https://developer.mozilla.org/en-US/docs/Web/HTTP/CSP)
2. [The OWASP cheat sheet](https://cheatsheetseries.owasp.org/cheatsheets/Content_Security_Policy_Cheat_Sheet.html)
3. [The Microsoft Reference](https://learn.microsoft.com/en-us/power-pages/security/manage-content-security-policy)
