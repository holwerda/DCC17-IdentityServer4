using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace IdSvrHost
{
    public class Config
    {
        public static IEnumerable<Client> GetClients()
        {
            return new Client[]
            {
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "Desert Code Camp MVC Demo",
                    //RequireConsent = false,         //this will either show the consent screen or not
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    ClientSecrets = { new Secret("secret".Sha256()) },          //should come from DB
                    RedirectUris =  { "http://localhost:47740/signin-oidc" },   //ms configuratable
                    LogoutUri = "http://localhost:47740/signout-oidc" ,         //iframe logout (allows to log out of all apps)
                    PostLogoutRedirectUris = { "http://localhost:47740/signout-callback-oidc" },  //this will allow sending back after logging out
                    AllowedScopes = { "openid", "profile", "email", "dcc", "dcc_api", "offline_access"  },  //use constants, also case sensitive
                    AllowOfflineAccess = true
                }
            };
        }
       
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email()
                {
                    Required = true,
                    Description = "This is giving the app access to your email address."
                }, 
                new IdentityResources.Profile(),

                //custom
                new IdentityResource
                {
                    Name = "dcc",
                    DisplayName = "DCC Room Number",
                    UserClaims = { "dcc_room_number" },
                    Required = true,
                    Description = "This is giving the app access to the desert code camp identity claims information"
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new ApiResource[]
            {
                new ApiResource("dcc_api", "DCC Api"),
            };
        }
    }
}
