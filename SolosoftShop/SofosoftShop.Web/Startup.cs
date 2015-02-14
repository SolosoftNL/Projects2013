using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SofosoftShop.Web.Startup))]
namespace SofosoftShop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
