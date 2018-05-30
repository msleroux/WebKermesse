using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebKermesse.Startup))]
namespace WebKermesse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
