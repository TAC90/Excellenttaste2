using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExcellentTaste.Startup))]
namespace ExcellentTaste
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
