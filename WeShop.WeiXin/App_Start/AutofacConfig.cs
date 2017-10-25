using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Mvc;

namespace WeShop
{
    public class AutofacConfig
    {
        public static void RegisterDenpendency()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            var service = Assembly.Load("WeShop.Service");
            var repository = Assembly.Load("WeShop.Repository");

            var IService = Assembly.Load("WeShop.IService");
            var IRepository = Assembly.Load("WeShop.IRepository");

            builder.RegisterAssemblyTypes(service,IService).Where(t=>t.Name.EndsWith("Service")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(repository,IRepository).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();


            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}