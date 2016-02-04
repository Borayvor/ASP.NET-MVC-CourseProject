using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Daga.Web.Startup))]
namespace Daga.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
