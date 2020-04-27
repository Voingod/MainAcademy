using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSharp_Net_module3_1_5_lab.Startup))]
namespace CSharp_Net_module3_1_5_lab
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
