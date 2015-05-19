using Owin;
using System.Web.Http;

namespace AnalisadorContabil.Testes.ApiRest
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }
    }
}
