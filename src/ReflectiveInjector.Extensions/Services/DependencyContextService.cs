using System;
using System.Collections.Generic;
using System.Linq;
using ReflectiveInjector.Extensions.Contracts;
using ReflectiveInjector.Extensions.Models;

namespace ReflectiveInjector.Extensions.Services
{
    internal class DependencyContextService
    {
        public IEnumerable<IDependencyRuntimeLibrary> RuntimeLibraries => Microsoft.Extensions.DependencyModel.DependencyContext.Default.RuntimeLibraries.Select((lib) => new DependencyRuntimeLibrary(lib.Name));

        public object CreateInstance(Type t)
        {
            return Activator.CreateInstance(t);
        }

        public Type[] GetAssemblyTypes(IDependencyRuntimeLibrary library)
        {
            return System.Reflection.Assembly.Load(new System.Reflection.AssemblyName(library.Name)).GetTypes();
        }
    }
}
