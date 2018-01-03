namespace SoT.Infra.CrossCutting.Identity.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SoT.Infra.CrossCutting.Identity.Context.AppDbContext>
    {
        public Configuration()
        {
            // TODO: set to false before launch
            AutomaticMigrationsEnabled = true;
            ContextKey = "SoT.Infra.CrossCutting.Identity.Context.AppDbContext";
        }

        protected override void Seed(SoT.Infra.CrossCutting.Identity.Context.AppDbContext context)
        {
            var claimAdmClaims = Claims.FactorySeed("6b97292c-01ea-48a3-90d4-eafa09b33d64", "AdmClaims");
            var claimManageProvider = Claims.FactorySeed("f26349fb-820d-4d4f-8d2c-9dd9cf922495", "ManageProvider");
            var claimAdmProvider = Claims.FactorySeed("4ccbb28f-4488-47ab-8d62-0770f64cb546", "AdmProvider");
            var claimAdmUsers = Claims.FactorySeed("13518f90-0a73-4de4-ade0-033d86de2ec7", "AdmUsers");

            context.Claims.AddOrUpdate(
                claimAdmClaims,
                claimManageProvider,
                claimAdmProvider,
                claimAdmUsers);

            // TODO: remove user addition after development
            var userAdmin = ApplicationUser.FactorySeed("f9babd79-00ca-4b97-83c7-b908f39d5585", "Admin", "Doe", "admin@email.com", @"ACcx4YaAQgp5LxJ75JphPcH6/LcXb/1WlPDWS/OXfIFSxs0tV1Fu9gDKgPnsSU/c8Q==", "b64a9f55-cb3f-4358-b1a9-058ab5676a20");
            userAdmin.Claims.Add(ConvertClaim(1, claimAdmClaims, userAdmin, "True"));
            userAdmin.Claims.Add(ConvertClaim(2, claimAdmUsers, userAdmin, "True"));

            var userProvider = ApplicationUser.FactorySeed("6e4175d4-7a7e-4e15-b225-1ad7b13e054c", "Provider", "Doe", "provider@email.com", @"AKTY/48QsaqvUlhRyfU7vbff39kMU4Lg8YTfLMfQk88dU1EkAhGjwLJv5ii5DL7XGw==", "cc6d9e2b-aad4-4f96-acda-ded430c613b7");
            userAdmin.Claims.Add(ConvertClaim(3, claimManageProvider, userProvider, "True"));

            context.Users.AddOrUpdate(
                userAdmin,
                userProvider
                );
        }

        private static IdentityUserClaim ConvertClaim(int id, Claims claim, ApplicationUser user, string claimValue)
        {
            return new IdentityUserClaim
            {
                Id = id,
                UserId = user.Id,
                ClaimType = claim.Name,
                ClaimValue = claimValue
            };
        }
    }
}
