using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StronglyTypedModelViewsDemo.Startup))]
namespace StronglyTypedModelViewsDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
