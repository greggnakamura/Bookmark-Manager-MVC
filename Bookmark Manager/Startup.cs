using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bookmark_Manager.Startup))]
namespace Bookmark_Manager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
