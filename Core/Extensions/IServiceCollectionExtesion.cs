using Core.DependencyResolvers;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class IServiceCollectionExtesion
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(services);
            }

            return ServiceTool.Create(services);
        }
    }
}
