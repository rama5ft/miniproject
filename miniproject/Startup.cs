using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using miniproject.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(miniproject.Startup))]
namespace miniproject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           // CreateRoles();
        }
        public async void CreateRoles()
        {
            var rolestore = new RoleStore<IdentityRole>(new ApplicationDbContext());
            var roleManager = new RoleManager<IdentityRole>(rolestore);
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            await roleManager.CreateAsync(new IdentityRole("Doctor"));

        }
    }
}
