using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5IdentityTest.Startup))]
namespace MVC5IdentityTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
