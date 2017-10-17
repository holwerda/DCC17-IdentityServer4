using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Test;

namespace IdSvrHost
{
    public class TestUsers
    {
        public static List<TestUser> Users = new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "12345",
                Username = "chris",
                Password = "test",
                Claims =
                {
                    new Claim(JwtClaimTypes.Name, "Chris Holwerda"),
                    new Claim(JwtClaimTypes.GivenName, "Chris"),
                    new Claim(JwtClaimTypes.FamilyName, "Holwerda"),
                    new Claim(JwtClaimTypes.Email, "chrisholwerda@chrisholwerda.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true"),
                    new Claim(JwtClaimTypes.WebSite, "https://chrisholwerda.com"),
                    new Claim(JwtClaimTypes.Address, "5555 Somewhere"),

                    //custom claims
                    new Claim("dcc_room_number", "IRN126")
                }
            }
        };
    }
}
