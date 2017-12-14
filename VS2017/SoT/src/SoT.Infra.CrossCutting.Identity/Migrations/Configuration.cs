namespace SoT.Infra.CrossCutting.Identity.Migrations
{
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

            context.Claims.AddOrUpdate(
                claimAdmClaims,
                claimManageProvider,
                claimAdmProvider);
        }
    }
}
