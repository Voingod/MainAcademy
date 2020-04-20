using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hello_CodeFirst_MVC.Startup))]
namespace Hello_CodeFirst_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
