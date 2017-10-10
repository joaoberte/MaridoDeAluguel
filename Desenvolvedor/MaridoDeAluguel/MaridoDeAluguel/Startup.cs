using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MaridoDeAluguel.Startup))]
namespace MaridoDeAluguel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
