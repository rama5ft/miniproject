using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(miniproject.Startup))]
namespace miniproject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
