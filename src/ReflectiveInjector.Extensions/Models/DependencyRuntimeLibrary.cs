using ReflectiveInjector.Extensions.Contracts;

namespace ReflectiveInjector.Extensions.Models
{
    internal class DependencyRuntimeLibrary : IDependencyRuntimeLibrary
    {
        public DependencyRuntimeLibrary(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
