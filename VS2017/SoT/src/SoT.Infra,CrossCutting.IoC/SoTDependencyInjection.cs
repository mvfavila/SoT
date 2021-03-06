﻿using Microsoft.AspNet.Identity;
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
using SoT.Infra.CrossCutting.Identity.Context;
using SoT.Infra.Data.Context;
using SoT.Infra.Data.Repositories;
using SoT.Infra.Data.Repositories.ReadOnly;

namespace SoT.Infra.CrossCutting.IoC
{
    public class SoTDependencyInjection
    {
        public static void RegisterServices(Container container)
        {
            // Infra

            // Infra - Data

            container.Register<SoTContext>(Lifestyle.Scoped);
            container.Register<AppDbContext>(Lifestyle.Scoped);

            container.Register<IExampleRepository, ExampleRepository>(Lifestyle.Scoped);
            container.Register<IExampleReadOnlyRepository, ExampleReadOnlyRepository>(Lifestyle.Scoped);
            container.Register<ISubExampleRepository, SubExampleRepository>(Lifestyle.Scoped);
            container.Register<ISubExampleReadOnlyRepository, SubExampleReadOnlyRepository>(Lifestyle.Scoped);
            container.Register<IProviderRepository, ProviderRepository> (Lifestyle.Scoped);
            container.Register<IProviderReadOnlyRepository, ProviderReadOnlyRepository> (Lifestyle.Scoped);
            container.Register<IEmployeeRepository, EmployeeRepository> (Lifestyle.Scoped);
            container.Register<IEmployeeReadOnlyRepository, EmployeeReadOnlyRepository>(Lifestyle.Scoped);
            container.Register<ICountryRepository, CountryRepository>(Lifestyle.Scoped);
            container.Register<ICountryReadOnlyRepository, CountryReadOnlyRepository>(Lifestyle.Scoped);
            container.Register<IAdventureRepository, AdventureRepository>(Lifestyle.Scoped);
            container.Register<IAdventureReadOnlyRepository, AdventureReadOnlyRepository>(Lifestyle.Scoped);
            container.Register<ICityRepository, CityRepository>(Lifestyle.Scoped);
            container.Register<ICityReadOnlyRepository, CityReadOnlyRepository>(Lifestyle.Scoped);
            container.Register<ICategoryRepository, CategoryRepository>(Lifestyle.Scoped);
            container.Register<ICategoryReadOnlyRepository, CategoryReadOnlyRepository>(Lifestyle.Scoped);
            container.Register<IMenuReadOnlyRepository, MenuReadOnlyRepository>(Lifestyle.Scoped);
            container.Register<IGenderReadOnlyRepository, GenderReadOnlyRepository>(Lifestyle.Scoped);


            // Infra - CrossCutting - Identity

            container.Register<IUserStore<ApplicationUser>>(
                () => new UserStore<ApplicationUser>(
                    new AppDbContext()
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

            // Domain

            container.Register<IExampleService, ExampleService>(Lifestyle.Scoped);
            container.Register<ISubExampleService, SubExampleService>(Lifestyle.Scoped);
            container.Register<IEmployeeService, EmployeeService>(Lifestyle.Scoped);
            container.Register<IProviderService, ProviderService>(Lifestyle.Scoped);
            container.Register<ICountryService, CountryService>(Lifestyle.Scoped);
            container.Register<IAdventureService, AdventureService>(Lifestyle.Scoped);
            container.Register<ICityService, CityService>(Lifestyle.Scoped);
            container.Register<ICategoryService, CategoryService>(Lifestyle.Scoped);
            container.Register<IMenuService, MenuService>(Lifestyle.Scoped);
            container.Register<IGenderService, GenderService>(Lifestyle.Scoped);

            // Application

            container.Register<IExampleAppService, ExampleAppService>(Lifestyle.Scoped);
            container.Register<IProviderAppService, ProviderAppService>(Lifestyle.Scoped);
            container.Register<ICountryAppService, CountryAppService>(Lifestyle.Scoped);
            container.Register<IAdventureAppService, AdventureAppService>(Lifestyle.Scoped);
            container.Register<ICityAppService, CityAppService>(Lifestyle.Scoped);
            container.Register<ICategoryAppService, CategoryAppService>(Lifestyle.Scoped);
            container.Register<IMenuAppService, MenuAppService>(Lifestyle.Scoped);
            container.Register<IGenderAppService, GenderAppService>(Lifestyle.Scoped);
        }
    }
}
