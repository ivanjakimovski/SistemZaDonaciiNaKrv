using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemZaDonaciiNaKrv.Startup))]
namespace SistemZaDonaciiNaKrv
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
