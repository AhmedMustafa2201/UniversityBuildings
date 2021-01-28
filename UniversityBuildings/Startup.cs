using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversityBuildings.Startup))]
namespace UniversityBuildings
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
