using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Arcus.Web.Startup))]
namespace Arcus.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
