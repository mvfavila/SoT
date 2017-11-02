using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace SoT.Infra.CrossCutting.Identity.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public AppDbContext()
            : base("SumOfThisConnection", throwIfV1Schema: false)
        {
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}
