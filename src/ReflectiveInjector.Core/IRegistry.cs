using Microsoft.Extensions.DependencyInjection;

namespace ReflectiveInjector.Core
{
    public interface IRegistry
    {
        void RegisterServices(IServiceCollection services);
    }
}
