using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using POC15.Models;
using POC15.Services;
using POC15.ViewModels;

namespace POC15
{
    static class AppContainer
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            // ViewModels
            builder.RegisterType<AboutViewModel>();
            builder.RegisterType<ItemDetailViewModel>();
            builder.RegisterType<ItemsViewModel>();
            builder.RegisterType<LoadingViewModel>();
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<NewItemViewModel>();

            // Services
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            builder.RegisterType<NavigationService>().As<INavigationService>();
            builder.RegisterType<MockDataStore>().As<IDataStore<Item>>().SingleInstance();
            
            container = builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        private static IContainer container;
    }
}
