using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoolGuide5.Startup))]
namespace SchoolGuide5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
