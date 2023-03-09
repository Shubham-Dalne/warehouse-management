using System.Web.Http;
using Unity;
using Unity.WebApi;
using WareHouseManagement.Interface;
using WareHouseManagement.Models;
using WareHouseManagement.Services;

namespace WareHouseManagement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // Implementing dependency injection.
            container.RegisterType<IWarehouse, WareHouse>(TypeLifetime.Singleton);
            container.RegisterType<IWareHouseService, WareHouseService>(TypeLifetime.Singleton);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}