using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiniFb.Startup))]
namespace MiniFb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
