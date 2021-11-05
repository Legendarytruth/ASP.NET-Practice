using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPlusSport.Web.IdentityServer
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
            new Client
            {
                Enabled = true,
                ClientName = "ASP.NET Web Security App",
                ClientId = "mvcapp",
                Flow = Flows.Implicit,

                RedirectUris = new List<string>
                {
                    "https://localhost:44329/"
                },

                AllowAccessToAllScopes = true
            }
        };
        }
    }
}