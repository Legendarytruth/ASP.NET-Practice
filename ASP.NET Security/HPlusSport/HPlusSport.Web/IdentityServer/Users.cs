using IdentityServer3.Core;
using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace HPlusSport.Web.IdentityServer
{
    public static class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>
            {
            new InMemoryUser
            {
                Username = "adam@example.com",
                Password = "Adam's secret",
                Subject = "1",

                Claims = new[]
                {
                    new Claim(Constants.ClaimTypes.GivenName, "Adam"),
                    new Claim(Constants.ClaimTypes.FamilyName, "West"),
                    new Claim(Constants.ClaimTypes.Role, "Admin")
                }
            },
            new InMemoryUser
            {
                Username = "barbara@example.com",
                Password = "b@rb@r@",
                Subject = "2",

                Claims = new[]
                {
                    new Claim(Constants.ClaimTypes.GivenName, "Barbara"),
                    new Claim(Constants.ClaimTypes.FamilyName, "Eden"),
                }
            }
            };
        }
    }
}