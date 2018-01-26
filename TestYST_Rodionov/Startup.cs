using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestYST_Rodionov.Startup))]
namespace TestYST_Rodionov
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
