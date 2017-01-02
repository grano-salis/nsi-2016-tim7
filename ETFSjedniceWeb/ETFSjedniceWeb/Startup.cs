using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ETFSjedniceWeb.Startup))]
namespace ETFSjedniceWeb
{
    
    public partial class Startup
    {
        public static string url = "http://esjedniceservis2.azurewebsites.net/";

        public void Configuration(IAppBuilder app)
        {
            
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
