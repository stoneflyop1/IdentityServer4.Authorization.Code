﻿

using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace oAuthCoreIdP
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            var secret = new Secret { Value = "mysecret".Sha512() };

            return new List<Client> {
                new Client {                    
                    ClientId = "mf",
                    ClientName = "Authorization Code Client",
                    ClientSecrets = new List<Secret>{ new Secret { Value = "Ywv14txfGNajhsd7Vues48H0R" } }, // { secret },
                    Enabled = true,
                    Flow = Flows.AuthorizationCode,
                    RequireConsent = false, //https://stackoverflow.com/questions/29784610/identityserver3-bypassing-the-consents-screen
                    AllowRememberConsent = false,
                    RedirectUris =
                      new List<string> {
                           "http://test.dbworld.cn/authentication/MFiles.AuthenticationProviders.OAuth/read",
                           "http://test.dbworld.cn"
                      },
                    PostLogoutRedirectUris =
                      new List<string> {"http://test.dbworld.cn/"},
                    AllowedScopes = new List<string> {
                        "api"
                    },
                    AccessTokenType = AccessTokenType.Jwt
                },
                new Client {
                    ClientId = "authorizationCodeClient2",
                    ClientName = "Authorization Code Client2",
                    ClientSecrets = new List<Secret> { secret },
                    Enabled = true,
                    Flow = Flows.AuthorizationCode,
                    RequireConsent = true,
                    AllowRememberConsent = false,
                    RedirectUris =
                      new List<string> {
                           "http://localhost:5436/account/oAuth2"
                      },
                    PostLogoutRedirectUris =
                      new List<string> {"http://localhost:5436"},
                    AllowedScopes = new List<string> {
                        "api"
                    }, EnableLocalLogin = true, 
                    AccessTokenType = AccessTokenType.Jwt
                }
            };
        }
    }
}