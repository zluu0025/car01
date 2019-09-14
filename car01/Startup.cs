using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(car01.Startup))]
namespace car01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
