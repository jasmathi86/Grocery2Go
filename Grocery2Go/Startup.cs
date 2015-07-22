using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Grocery2Go.Startup))]
namespace Grocery2Go
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
