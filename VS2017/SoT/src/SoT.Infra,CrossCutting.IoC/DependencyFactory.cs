using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace SoT.Infra.CrossCutting.IoC
{   
    /// <summary>
    /// Wrapper for Unity DI resolution.
    /// </summary>
    public class DependencyFactory
    {
        private static IUnityContainer container;

        /// <summary>
        /// Public reference to the unity container which will allow the ability to register instrances or take<br/> 
        /// other actions on the container.
        /// </summary>
        public static  IUnityContainer Container
        {
            get
            {
                return container;
            }
            set
            {
                container = value;
            }
        }

        /// <summary>
        /// Static constructor for DependencyFactory which will 
        /// initialize the unity container.
        /// </summary>
        static DependencyFactory()
        {
            var cont = new UnityContainer();

            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            if (section != null)
            {
                section.Configure(cont);
            }
            container = cont;
        }
    }
}
