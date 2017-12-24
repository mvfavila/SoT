using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SoT.Infra.CrossCutting.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Clients = new Collection<Client>();
        }

        public string Name { get; set; }
        public string Lastname { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        [NotMapped]
        public string CurrentClientId { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager,
            ClaimsIdentity ext = null)
        {
            // authenticationType must be the same that was defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            var claims = new List<Claim>();

            if (!string.IsNullOrEmpty(CurrentClientId))
            {
                claims.Add(new Claim("AspNet.Identity.ClientId", CurrentClientId));
            }

            //  Add new Claims here //

            // Adding extenal Claims recovered from login
            if (ext != null)
            {
                await SetExternalProperties(userIdentity, ext);
            }

            // Claims management for user info
            //claims.Add(new Claim("AdmRoles", "True"));

            userIdentity.AddClaims(claims);

            return userIdentity;
        }

        private async Task SetExternalProperties(ClaimsIdentity identity, ClaimsIdentity ext)
        {
            if (ext != null)
            {
                const string ignoreClaim = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims";
                // Adding external Claims into Identity
                foreach (var c in ext.Claims)
                {
                    if (!c.Type.StartsWith(ignoreClaim))
                        if (!identity.HasClaim(c.Type, c.Value))
                            identity.AddClaim(c);
                }
            }
        }
    }
}
