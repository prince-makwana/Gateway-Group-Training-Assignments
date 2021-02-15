using System.Web.Http;
using Unity;
using Unity.WebApi;
using PMS.BAL.Helper;
using PMS.BAL.ManagerClass;
using PMS.BAL.ManagerInterface;

namespace PMS.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.AddNewExtension<UnityRepositoryHelper>();

            container.RegisterType<IUserManager, UserManager>();
            container.RegisterType<IProductManager, ProductManager>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}