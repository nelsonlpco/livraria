using Livraria.Web.IoC;
using System.Web.Mvc;
using System.Web.Routing;

namespace LivrariaHBSIS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            UnityBootstrapper.Initialise();

        }
    }
}
