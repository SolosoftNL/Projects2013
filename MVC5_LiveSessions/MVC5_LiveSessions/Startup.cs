using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5_LiveSessions.Startup))]
namespace MVC5_LiveSessions
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
