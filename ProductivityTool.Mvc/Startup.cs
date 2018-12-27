using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductivityTool.Mvc.Startup))]
namespace ProductivityTool.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
