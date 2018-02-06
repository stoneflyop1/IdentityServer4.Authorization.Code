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
        public static IEnumerable<IdentityResource> Get()
        {
            return new List<IdentityResource> {
                new IdentityResource()
                {
                    Name = "api",
                    DisplayName = "api scope",
                    Required = true, 
                    //Type = ScopeType.Resource,
                    Emphasize = false,
                    //https://github.com/IdentityServer/IdentityServer3/issues/1784
                    UserClaims = new List<string> { ClaimTypes.NameIdentifier }
                }
            };
        }

        public static IEnumerable<ApiResource> GetApi()
        {
            return new List<ApiResource> {
                new ApiResource()
                {                    
                    Name = "api",
                    DisplayName = "api scope",
                    //https://github.com/IdentityServer/IdentityServer3/issues/1784
                    UserClaims = new List<string> { ClaimTypes.NameIdentifier }, Enabled = true,
                    Scopes = new List<Scope>
                    {
                        new Scope
                        {
                            Name = "api",
                            DisplayName = "api scope", Required = true,
                            Emphasize = false,
                            //https://github.com/IdentityServer/IdentityServer3/issues/1784
                            UserClaims = new List<string>{ ClaimTypes.NameIdentifier }
                        }
                    }
                }
            };
        }

    }
}