using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TenisProjesi.Startup))]
namespace TenisProjesi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
             app.MapSignalR();
        }
    }
}
