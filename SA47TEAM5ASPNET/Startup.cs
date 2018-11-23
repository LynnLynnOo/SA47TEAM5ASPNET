using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SA47TEAM5ASPNET.Startup))]
namespace SA47TEAM5ASPNET
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
