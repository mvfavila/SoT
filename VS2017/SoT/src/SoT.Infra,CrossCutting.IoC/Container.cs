using Ninject;

namespace SoT.Infra.CrossCutting.IoC
{
    public class Container
    {
        public StandardKernel GetModule()
        {
            return new StandardKernel(
                new Ninject()
                );
        }
    }
}
