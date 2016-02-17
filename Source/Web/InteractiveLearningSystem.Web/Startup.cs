using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(InteractiveLearningSystem.Web.Startup))]

namespace InteractiveLearningSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
