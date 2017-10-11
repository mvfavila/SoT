using Ninject.Modules;

namespace SoT.Infra.CrossCutting.IoC
{
    public class Ninject : NinjectModule
    {
        public override void Load()
        {
            // application

            // service

            // data repository

            // data configuration

            //Sample:
            // Bind<ISampleRepository>().To<SampleRepository>();
            throw new System.NotImplementedException();
        }
    }
}
