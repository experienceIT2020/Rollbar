using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RBFramework.Startup))]
namespace RBFramework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
