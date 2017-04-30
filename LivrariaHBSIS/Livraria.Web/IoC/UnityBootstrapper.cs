using LivrariaHBSIS.ServiceLocator;
using Microsoft.Practices.Unity.Mvc;
using System.Web.Mvc;

namespace Livraria.Web.IoC
{
    public static class UnityBootstrapper
    {
        public static void Initialise()
        {
            var container = new BuilderUnityContainer().BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

    }
}