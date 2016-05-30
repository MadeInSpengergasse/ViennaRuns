using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VIennaRuns.Startup))]
namespace VIennaRuns
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
