using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Hosting;
using System.Runtime.Loader;

namespace SleeveArrow.IOC;

public static class DenpendencyBuilder
{
    public static IHostBuilder UseAutofac(this IHostBuilder hostBuilder)
    {
        hostBuilder.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        hostBuilder.ConfigureContainer<ContainerBuilder>(container =>
        {
            var libs = DependencyContext.Default!.CompileLibraries.Where(d => d.Serviceable == false && d.Type == "project").Select(d => d.Name).ToList();
            var assembliew = libs.Select(d => AssemblyLoadContext.Default.LoadFromAssemblyName(new System.Reflection.AssemblyName(d))).ToArray();

            container.RegisterAssemblyTypes(assembliew)
            .Where(d => !d.IsAbstract && d.IsAssignableTo(typeof(ISingletonDependency)))
            .AsSelf()
            .AsImplementedInterfaces()
            .SingleInstance()
            .PropertiesAutowired();

            container.RegisterAssemblyTypes(assembliew)
            .Where(d => !d.IsAbstract && d.IsAssignableTo(typeof(ITransientDependency)))
            .AsSelf()
            .AsImplementedInterfaces()
            .InstancePerDependency()
            .PropertiesAutowired();

            container.RegisterAssemblyTypes(assembliew)
            .Where(d => !d.IsAbstract && d.IsAssignableTo(typeof(ITransientDependency)))
            .AsSelf()
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope()
            .PropertiesAutowired();
        });

        return hostBuilder;
    }
}