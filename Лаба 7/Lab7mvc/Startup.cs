using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab7mvc.Startup))]
namespace Lab7mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
