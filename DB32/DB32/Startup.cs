using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DB32.Startup))]
namespace DB32
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
