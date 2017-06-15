using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCTutorial17.Startup))]
namespace MVCTutorial17
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
