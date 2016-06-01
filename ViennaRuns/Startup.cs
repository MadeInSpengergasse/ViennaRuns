using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ViennaRuns.Startup))]
namespace ViennaRuns
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
