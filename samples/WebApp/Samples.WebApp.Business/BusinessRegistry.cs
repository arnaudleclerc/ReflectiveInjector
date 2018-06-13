using Microsoft.Extensions.DependencyInjection;
using ReflectiveInjector.Core;

namespace Samples.WebApp.Business
{
    internal class BusinessRegistry : IRegistry
    {
        public void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IDataBusiness, DataBusiness>();
        }
    }
}
