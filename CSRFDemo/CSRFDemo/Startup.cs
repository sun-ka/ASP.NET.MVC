using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSRFDemo.Startup))]
namespace CSRFDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
