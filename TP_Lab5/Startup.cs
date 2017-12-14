using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TP_Lab5.Startup))]
namespace TP_Lab5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
