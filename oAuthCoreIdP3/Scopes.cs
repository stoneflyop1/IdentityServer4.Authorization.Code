using IdentityServer3.Core.Models;
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
                new Scope()
                {
                    Name = "api",
                    DisplayName = "api scope",
                    Required = true, 
                    //Type = ScopeType.Resource,
                    Emphasize = false,
                    Claims = new List<ScopeClaim>
                    {
                        new ScopeClaim{Name = ClaimTypes.NameIdentifier, AlwaysIncludeInIdToken=true}
                    }
                }
            };
        }       

    }
}