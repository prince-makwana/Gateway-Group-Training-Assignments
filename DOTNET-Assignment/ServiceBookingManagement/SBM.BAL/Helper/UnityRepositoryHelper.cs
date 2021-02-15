using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Extension;
using Unity;
using SBM.DAL.RepositoryClass;
using SBM.DAL.RepositoryInterface;

namespace SBM.BAL.Helper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IAppointmentRepository, AppointmentRepository>();
            Container.RegisterType<ICustomerRepository, CustomerRepository>();
            Container.RegisterType<IDealerRepository, DealerRepository>();
            Container.RegisterType<IJobCardRepository, JobCardRepository>();
            Container.RegisterType<IMechanicRepository, MechanicRepository>();
            Container.RegisterType<IRecordRepository, RecordRepository>();
            Container.RegisterType<IServiceRepository, ServiceRepository>();
            Container.RegisterType<IVehicleRepository, VehicleRepository>();
            Container.RegisterType<IAccountRepository, AccountRepository>();
        }
    }
}
