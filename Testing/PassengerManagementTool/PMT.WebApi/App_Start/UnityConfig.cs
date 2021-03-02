using PMT.BAL;
using PMT.BAL.Helper;
using PMT.BAL.Interface;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace PMT.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.AddNewExtension<UnityExtensionHelper>();

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IPassengerManager, PassengerManager>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}