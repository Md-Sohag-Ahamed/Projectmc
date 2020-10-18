using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Projectmc.Startup))]
namespace Projectmc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
