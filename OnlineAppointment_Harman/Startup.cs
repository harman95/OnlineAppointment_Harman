using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineAppointment_Harman.Startup))]
namespace OnlineAppointment_Harman
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
