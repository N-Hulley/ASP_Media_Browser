using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(View.Startup))]
namespace View
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
