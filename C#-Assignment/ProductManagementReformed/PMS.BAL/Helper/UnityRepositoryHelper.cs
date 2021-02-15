using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Extension;
using Unity;
using PMS.DAL.RepositoryClass;
using PMS.DAL.RepositoryInterface;

namespace PMS.BAL.Helper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IUserRepository, UserRepository>();
            Container.RegisterType<IProductRepository, ProductRepository>();
        }
    }
}
