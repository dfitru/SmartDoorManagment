using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartDoorManagmentSystem.MVC.Startup))]
namespace SmartDoorManagmentSystem.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
