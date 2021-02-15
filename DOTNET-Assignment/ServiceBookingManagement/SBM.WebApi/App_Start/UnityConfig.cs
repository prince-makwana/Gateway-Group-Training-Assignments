using System.Web.Http;
using Unity;
using Unity.WebApi;
using SBM.BAL.Helper;
using SBM.BAL.ManagerClass;
using SBM.BAL.ManagerInterface;

namespace SBM.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IAppointmentManager, AppointmentManager>();
            container.RegisterType<ICustomerManager, CustomerManager>();
            container.RegisterType<IDealerManager, DealerManager>();
            container.RegisterType<IJobCardManager, JobCardManager>();
            container.RegisterType<IMechanicManager, MechanicManager>();
            container.RegisterType<IRecordManager, RecordManager>();
            container.RegisterType<IServiceManager, ServiceManager>();
            container.RegisterType<IVehicleManager, VehicleManager>();
            container.RegisterType<IAccountManager, AccountManager>();

            container.AddNewExtension<UnityRepositoryHelper>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}