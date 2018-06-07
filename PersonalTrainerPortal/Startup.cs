using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PersonalTrainerPortal.Startup))]
namespace PersonalTrainerPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
