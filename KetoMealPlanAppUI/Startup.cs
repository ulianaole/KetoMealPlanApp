using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KetoMealPlanAppUI.Startup))]
namespace KetoMealPlanAppUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
