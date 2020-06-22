using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Code_Box.Startup))]
namespace Code_Box
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
