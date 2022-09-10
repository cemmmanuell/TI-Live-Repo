using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mmmSelfservice.Startup))]
namespace mmmSelfservice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
