using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ReflectiveInjector.Core;
using ReflectiveInjector.Extensions.Contracts;
using ReflectiveInjector.Extensions.Services;

namespace ReflectiveInjector.Extensions
{
    public static class ReflectiveInjectorMiddleware
    {
        /// <summary>
        /// Registers the services using dependency injection
        /// </summary>
        /// <param name="services">Service collection used for the injection</param>
        /// <param name="libraryStartName">Start name of the libraries on which the injector will look for services to register</param>
        public static void AddTekarisDependencyInjection(this IServiceCollection services, string libraryStartName)
        {
            var dependencyContextService = new DependencyContextService();

            foreach (var library in dependencyContextService.RuntimeLibraries
                .Where((lib) => lib.Name.ToLower().StartsWith(libraryStartName)))
            {
                dependencyContextService.GetAssemblyTypes(library)
                    .Where(t => t.GetTypeInfo().IsClass && !t.GetTypeInfo().IsAbstract && typeof(IRegistry).GetTypeInfo().IsAssignableFrom(t))
                    .ToList()
                    .ForEach((t) =>
                    {
                        var registry = (IRegistry)dependencyContextService.CreateInstance(t);
                        registry.RegisterServices(services);
                    });
            }
        }
    }
}
