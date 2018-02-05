using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace oAuthCoreIdP
{
    public class Scopes
    {
        // scopes define the resources in your system
        public static IEnumerable<Scope> Get()
        {
            return new List<Scope> {
                new Scope
                {
                    Name = "api",
                    DisplayName = "api scope",
                    Type = ScopeType.Resource,
                    Emphasize = false,
                    //https://github.com/IdentityServer/IdentityServer3/issues/1784
                    Claims = new List<ScopeClaim>{ new ScopeClaim(ClaimTypes.NameIdentifier, alwaysInclude: true) }
                }
            };
        }
    }
}