using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FormsAuthenticationDemo.Startup))]
namespace FormsAuthenticationDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
