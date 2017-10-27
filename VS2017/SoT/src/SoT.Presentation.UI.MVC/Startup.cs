using Microsoft.Owin;
using Owin;
using SoT.Presentation.UI.MVC;

[assembly: OwinStartup(typeof(Startup))]
namespace SoT.Presentation.UI.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}