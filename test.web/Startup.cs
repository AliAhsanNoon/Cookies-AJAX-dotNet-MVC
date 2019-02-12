using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(test.web.Startup))]
namespace test.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
