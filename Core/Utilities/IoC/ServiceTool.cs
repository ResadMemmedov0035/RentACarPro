using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        private static IServiceProvider? serviceProvider;

        public static IServiceProvider ServiceProvider 
        {
            get => serviceProvider ?? throw new Exception("Service Provider can't be null."); 
            private set => serviceProvider = value; 
        }

        public static void SetProvider(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
        }

        //public static void SetProvider(IServiceProvider provider)
        //{
        //    ServiceProvider = provider;
        //}

        //public static void SetAutofacProvider(ContainerBuilder builder) 
        //{
        //    ServiceProvider = new AutofacServiceProvider(builder.Build());
        //}
    }
}
