using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CaveRegister.Startup))]
namespace CaveRegister
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
