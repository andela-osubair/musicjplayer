using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MusicJPlayer.Startup))]
namespace MusicJPlayer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
