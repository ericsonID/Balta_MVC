using System.Web.Mvc;
using BookStore.Context;
using BookStore.Repositories;
using BookStore.Repositories.Context;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace BookStore
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IAuthorRepository, AuthorRepository>();
            container.RegisterType<BookStoreDataContext, BookStoreDataContext>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}