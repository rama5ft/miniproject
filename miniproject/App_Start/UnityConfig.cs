using miniproject.Interface;
using miniproject.Repository;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace miniproject
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ILogin, AllRepository>();
            container.RegisterType<CommonInterface, AllRepository>();
          container.RegisterType<PatientDetails, AllRepository>();
           
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}