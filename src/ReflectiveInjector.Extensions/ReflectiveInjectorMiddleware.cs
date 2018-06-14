using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ReflectiveInjector.Core;
using ReflectiveInjector.Extensions.Services;

namespace ReflectiveInjector.Extensions
{
    public static class ReflectiveInjectorMiddleware
    {
        /// <summary>
        /// Registers services using reflection
        /// </summary>
        /// <param name="services">Service collection used for the injection</param>
        /// <param name="libraryStartName">Start name of the libraries on which the injector will look for services to register</param>
        public static IServiceCollection AddReflectorDependencies(this IServiceCollection services, string libraryStartName)
        {
            if (string.IsNullOrWhiteSpace(libraryStartName))
            {
                throw new ArgumentException("A start name for the libraries to look into should be provided");
            }

            var dependencyContextService = new DependencyContextService();

            foreach (var library in dependencyContextService.RuntimeLibraries
                .Where((lib) => lib.Name.ToLower().StartsWith(libraryStartName.ToLower())))
            {
                foreach (var type in dependencyContextService.GetAssemblyTypes(library)
                    .Where(t => t.GetTypeInfo().IsClass && !t.GetTypeInfo().IsAbstract &&
                                typeof(IRegistry).GetTypeInfo().IsAssignableFrom(t)))
                {
                    var registry = (IRegistry)dependencyContextService.CreateInstance(type);
                    registry.RegisterServices(services);
                }
            }

            return services;
        }
    }
}
