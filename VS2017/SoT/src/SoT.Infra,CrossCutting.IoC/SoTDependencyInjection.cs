using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;
using SoT.Application.AppServices;
using SoT.Application.Interfaces;
using SoT.Domain.Interfaces.Repository;
using SoT.Domain.Interfaces.Repository.ReadOnly;
using SoT.Domain.Interfaces.Services;
using SoT.Domain.Services;
using SoT.Infra.CrossCutting.Identity;
using SoT.Infra.CrossCutting.Identity.Configuration;
using SoT.Infra.Data.Context;
using SoT.Infra.Data.Repositories;
using SoT.Infra.Data.Repositories.ReadOnly;

namespace SoT.Infra.CrossCutting.IoC
{
    public class SoTDependencyInjection
    {
        public static void RegisterServices(Container container)
        {
            container.Register<SoTContext>(Lifestyle.Scoped);
            container.Register<IdentityContext>(Lifestyle.Scoped);

            container.Register<ISubExampleRepository, SubExampleRepository>(Lifestyle.Scoped);
            container.Register<IExampleRepository, ExampleRepository>(Lifestyle.Scoped);
            container.Register<IExampleReadOnlyRepository, ExampleReadOnlyRepository>(Lifestyle.Scoped);

            container.Register<IExampleService, ExampleService>(Lifestyle.Scoped);
            container.Register<ISubExampleService, SubExampleService>(Lifestyle.Scoped);
            container.Register<IExampleAppService, ExampleAppService>(Lifestyle.Scoped);

            container.Register<IUserStore<ApplicationUser>>(
                () => new UserStore<ApplicationUser>(
                    new SoTContext()
                ),
                Lifestyle.Scoped
            );

            container.Register<IRoleStore<IdentityRole, string>>(
                () => new RoleStore<IdentityRole>(),
                Lifestyle.Scoped
            );

            container.Register<ApplicationRoleManager>(Lifestyle.Scoped);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);
        }
    }
}
