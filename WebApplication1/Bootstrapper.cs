using System.Web.Mvc;
using WebApplication1.Domain;
using Microsoft.Practices.Unity;
using Unity.Mvc4;

namespace WebApplication1
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            RegisterTypes(container);

            return container;
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IPlaceRepository, DummyPlaceRepository>(new ContainerControlledLifetimeManager());
        }
    }
}