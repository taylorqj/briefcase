using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(briefcase.Startup))]
namespace briefcase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
