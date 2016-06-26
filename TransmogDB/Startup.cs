using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TransmogDB.Startup))]
namespace TransmogDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
