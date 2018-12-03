using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CourseSite.Startup))]
namespace CourseSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
