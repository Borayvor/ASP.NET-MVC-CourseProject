using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(EntertainmentSystem.Web.Startup))]

namespace EntertainmentSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
