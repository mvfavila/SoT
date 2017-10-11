using Ninject.Modules;
using SoT.Application.AppServices;
using SoT.Application.Interfaces;
using SoT.Domain.Interfaces.Repository;
using SoT.Infra.Data.Repositories;

namespace SoT.Infra.CrossCutting.IoC
{
    public class Ninject : NinjectModule
    {
        // TODO: create a differente class of IoC per SoT application function and register each
        // class as a "Ninject" class. e.g. Client registration.

        public override void Load()
        {
            // application
            Bind<IExampleAppService>().To<ExampleAppService>();

            // service

            // data repository
            Bind<IExampleRepository>().To<ExampleRepository>();
            Bind<ISubExampleRepository>().To<SubExampleRepository>();

            // data configuration

        }
    }
}
