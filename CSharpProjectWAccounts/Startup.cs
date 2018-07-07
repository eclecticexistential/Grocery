using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSharpProjectWAccounts.Startup))]
namespace CSharpProjectWAccounts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
