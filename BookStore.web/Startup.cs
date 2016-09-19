using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookStore.web.Startup))]
namespace BookStore.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
