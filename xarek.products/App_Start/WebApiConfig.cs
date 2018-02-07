using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using xarek.products.domain.Implementation;
using xarek.products.domain.Infrastructure;
using xarek.products.domain.interfaces;

namespace xarek.products
{
    public static class WebApiConfig
    {
        private static IKernel ninjectKernel;

        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            AddBindings();

            config.DependencyResolver = new NinjectResolver(ninjectKernel);
        }

        private static void AddBindings()
        {
            ninjectKernel = new StandardKernel();

            ninjectKernel.Bind<IproductREPO>().To<DBProductRepo>();
        }
    }
}
