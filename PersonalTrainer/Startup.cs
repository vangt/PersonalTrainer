using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PersonalTrainer.Startup))]
namespace PersonalTrainer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
