using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ElevenNote.Web.Startup))]
namespace ElevenNote.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
