using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ETFSjedniceWeb.Startup))]
namespace ETFSjedniceWeb
{
    
    public partial class Startup
    {
        public static string url = "http://localhost:59051/";

        public void Configuration(IAppBuilder app)
        {
            
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
