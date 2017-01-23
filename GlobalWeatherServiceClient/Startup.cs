using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GlobalWeatherServiceClient.Startup))]
namespace GlobalWeatherServiceClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
