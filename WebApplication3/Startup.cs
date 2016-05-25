using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CultureBase.Startup))]
namespace CultureBase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
