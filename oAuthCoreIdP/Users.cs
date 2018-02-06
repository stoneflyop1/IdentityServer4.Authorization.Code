﻿
using IdentityServer4.Test;
using oAuthCoreIdP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;


namespace oAuthCoreIdP
{
    public static class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser> {
                new InMemoryUser {
                    Subject = "1",
                    Username = "admin",
                    Password = "pass123",
                    Claims = new List<Claim> {
                        new Claim(ClaimTypes.NameIdentifier, "admin"), //AccountClaim
                        new Claim(ClaimTypes.GivenName, "GivenName"),
                        new Claim(ClaimTypes.Surname, "surname"), //DELTA //.FamilyName in IdentityServer3
                        new Claim(ClaimTypes.Email, "user@somesecurecompany.com"),
                        new Claim(ClaimTypes.Role, "Badmin")
                    }
                }
            };
        }

        public static List<TestUser> GetTest()
        {
            return new List<TestUser> {
                new TestUser {
                    Username = "admin",
                    Password = "pass123",
                    SubjectId = "1",
                    Claims = new List<Claim> {
                        new Claim(ClaimTypes.NameIdentifier, "admin"), //AccountClaim
                        new Claim(ClaimTypes.GivenName, "GivenName"),
                        new Claim(ClaimTypes.Surname, "surname"), //DELTA //.FamilyName in IdentityServer3
                        new Claim(ClaimTypes.Email, "user@somesecurecompany.com"),
                        new Claim(ClaimTypes.Role, "Badmin")
                    }
                }
            };
        }
    }
}