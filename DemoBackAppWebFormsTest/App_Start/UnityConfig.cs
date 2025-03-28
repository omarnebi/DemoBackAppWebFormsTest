using DemoBackAppWebFormsTest.BLL.IService;
using DemoBackAppWebFormsTest.BLL.Service;
using DemoBackAppWebFormsTest.BLL;
using DemoBackAppWebFormsTest.DAL.IRepository;
using DemoBackAppWebFormsTest.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity.Lifetime;
using Unity;
using DemoBackAppWebFormsTest.DAL.Repository;

namespace DemoBackAppWebFormsTest.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Enregistrement des dépendances
            container.RegisterType<MyDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IUserService, UserService>();

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}